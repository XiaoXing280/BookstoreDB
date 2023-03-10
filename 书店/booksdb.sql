USE [master]
GO
/****** Object:  Database [BooksDB]    Script Date: 2022/9/9 15:05:43 ******/
CREATE DATABASE [BooksDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BooksDB', FILENAME = N'E:\实训项目\一项目资料\DB\BooksDB1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BooksDB_log', FILENAME = N'E:\实训项目\一项目资料\DB\BooksDB_log1.ldf' , SIZE = 10176KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BooksDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BooksDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BooksDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BooksDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BooksDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BooksDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BooksDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BooksDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BooksDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BooksDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BooksDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BooksDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BooksDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BooksDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BooksDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BooksDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BooksDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BooksDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BooksDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BooksDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BooksDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BooksDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BooksDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BooksDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BooksDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BooksDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BooksDB] SET  MULTI_USER 
GO
ALTER DATABASE [BooksDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BooksDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BooksDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BooksDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BooksDB', N'ON'
GO
USE [BooksDB]
GO
/****** Object:  StoredProcedure [dbo].[proc_page]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--通用分页存储过程
CREATE proc [dbo].[proc_page]
@pageIndex int=1,--页索引
@pageSize int=10,--页大小
@tableName varchar(100),--表名
@keyName varchar(100),--主键名
@filter varchar(1000)='*',--查询字段
@where varchar(1000)='',--where条件
@order varchar(1000)='',--排序条件
@dataCount int output--总记录数，输出参数
as

declare @sql nvarchar(2000)--必须nvarchar
declare @where1 nvarchar(1000),@where2 nvarchar(1000)
if(@where='')
begin
	set @where1=''
	set @where2=''
end
else
begin
	set @where1=' where '+@where
	set @where2= ' and ' + @where
end
declare @order1 nvarchar(1000)
if(@order='')
	set @order1=' order by '+@keyName
else
	set @order1=' order by ' +@order

if(@pageIndex=1)--第一页
begin
	set @sql='select top '+convert(varchar(10),@pageSize)+' '+@filter
					+' from '+@tableName+@where1+@order1
end
else--其他页
begin
	set @sql = 'select top '+convert(varchar(10),@pageSize)
					  +' '+@filter+' from '+@tableName+'
						where '+@keyName+' not in
						(select top '+convert(varchar(10),(@pageIndex-1)*@pageSize)
						+' '+@keyName+' from '
						+@tableName+@where1+@order1+') '
						+@where2+@order1
end
--执行字符串的SQL命令
exec(@sql)
--查询获取总记录数
set @sql='select @count=count(*) from '+@tableName+@where1
--执行带参数的字符串SQL命令
exec sp_executesql @sql,N'@count int output',@count=@dataCount output

----------------运行存储过程-------------------
--declare @count int
--exec proc_page @pageIndex=2,@pageSize=5
--,@tableName='orders',@keyName='orderID'
--,@where='EmployeeID=4',@order='OrderDate desc'
--,@filter='orderID,CustomerID,EmployeeID,OrderDate'
--,@dataCount=@count output
--select @count


GO
/****** Object:  UserDefinedFunction [dbo].[BuildNum]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION   [dbo].[BuildNum]() RETURNS varchar(100)
AS
BEGIN
	DECLARE @dd VARCHAR(100)
	SET @dd= 'DD'+CONVERT(VARCHAR(100),GETDATE(),112)
	DECLARE @all VARCHAR(100)
	IF EXISTS(SELECT OrderNum FROM dbo.Orders WHERE OrderNum LIKE @dd+'%')
	BEGIN
		SELECT TOP 1 @all = OrderNum FROM dbo.Orders WHERE OrderNum LIKE @dd+'%' ORDER BY OrderNum DESC
		SET @all = SUBSTRING(@all,11,4)
		DECLARE @num INT
		SET @num=CONVERT(INT,@all)+10001
		SET @all=@dd+SUBSTRING(CONVERT(VARCHAR(100),@num),2,4)
	END
	ELSE
		SET @all=@dd+'0001'

	RETURN @all
END
GO
/****** Object:  Table [dbo].[AddressManager]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AddressManager](
	[AMID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[AMUser] [nvarchar](100) NULL,
	[AMTel] [varchar](100) NULL,
	[AMAddress] [nvarchar](500) NULL,
	[AMMark] [bit] NULL,
 CONSTRAINT [PK_ADDRESSMANAGER] PRIMARY KEY CLUSTERED 
(
	[AMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[AdminUser] [nvarchar](50) NULL,
	[AdminPwd] [char](47) NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BLCategory]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BLCategory](
	[BLID] [int] IDENTITY(1,1) NOT NULL,
	[BLName] [nvarchar](100) NULL,
 CONSTRAINT [PK_BLCATEGORY] PRIMARY KEY CLUSTERED 
(
	[BLID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookAppraise]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAppraise](
	[BAID] [int] IDENTITY(1,1) NOT NULL,
	[ODID] [int] NULL,
	[BADesc] [nvarchar](500) NULL,
	[BAPoint] [int] NULL,
	[BADate] [datetime] NULL,
 CONSTRAINT [PK_BOOKAPPRAISE] PRIMARY KEY CLUSTERED 
(
	[BAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BSID] [int] NULL,
	[BookTitle] [nvarchar](1000) NULL,
	[BookAuthor] [nvarchar](1000) NULL,
	[BookPublish] [nvarchar](100) NULL,
	[ISBN] [nvarchar](100) NULL,
	[BookCount] [int] NULL,
	[BookMoney] [numeric](8, 2) NULL,
	[BookPrice] [numeric](8, 2) NULL,
	[BookDesc] [text] NULL,
	[BookAuthorDesc] [text] NULL,
	[BookComm] [text] NULL,
	[BookContent] [text] NULL,
	[BookSale] [int] NULL,
	[BookDeport] [int] NULL,
	[BookIsBuy] [bit] NULL,
	[BookIsHot] [bit] NULL,
	[BookIsDelete] [bit] NULL,
	[BookBuyDate] [datetime] NULL,
	[BookHotDate] [datetime] NULL,
 CONSTRAINT [PK_BOOKS] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BSCategory]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BSCategory](
	[BSID] [int] IDENTITY(1,1) NOT NULL,
	[BLID] [int] NULL,
	[BSName] [nvarchar](100) NULL,
 CONSTRAINT [PK_BSCATEGORY] PRIMARY KEY CLUSTERED 
(
	[BSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ODID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[BookID] [int] NULL,
	[ODPrice] [numeric](8, 2) NULL,
	[ODCount] [int] NULL,
	[ODMoney] [numeric](12, 2) NULL,
 CONSTRAINT [PK_ORDERDETAIL] PRIMARY KEY CLUSTERED 
(
	[ODID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[AMID] [int] NULL,
	[OrderNum] [char](14) NULL,
	[OrderDate] [datetime] NULL,
	[OrderState] [int] NULL,
	[OrderMoney] [numeric](12, 2) NULL,
 CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPwd] [char](47) NULL,
	[UserEmail] [varchar](50) NULL,
	[UserSex] [varchar](10) NULL,
	[UserNick] [nvarchar](50) NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[View_Books]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Books]
AS 
SELECT  BookAuthor ,
        BookAuthorDesc ,
        BookBuyDate ,
        BookComm ,
        BookContent ,
        BookCount ,
        BookDeport ,
        BookDesc ,
        BookHotDate ,
        BookID ,
        BookIsBuy ,
        BookIsDelete ,
        BookIsHot ,
        BookMoney ,
        BookPrice ,
        BookPublish ,
        BookSale ,
        BookTitle ,
        a.BSID ,
        ISBN, 
		c.BSName,b.BLName,c.BLID FROM dbo.Books AS a,dbo.BLCategory AS b,dbo.BSCategory AS c
		WHERE a.BookIsDelete=0 AND a.BSID=c.BSID AND b.BLID=c.BLID

GO
/****** Object:  View [dbo].[View_BSCategory]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_BSCategory]
AS
SELECT BSID,BSName,a.BLID,BLName  FROM dbo.BSCategory AS a,dbo.BLCategory AS b
WHERE a.BLID=b.BLID
GO
/****** Object:  View [dbo].[View_OrderDetail]    Script Date: 2022/9/9 15:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_OrderDetail]
as
SELECT a.ODID,a.bookid,ODPrice,ODCount,BAID= CASE
	WHEN b.BAID IS NULL THEN -1
	ELSE b.BAID
end,c.ISBN,d.UserID,d.OrderState,c.BookTitle FROM dbo.OrderDetail AS a LEFT JOIN dbo.BookAppraise AS b 
ON a.odid=b.ODID INNER JOIN books c ON a.BookID=c.BookID INNER JOIN dbo.Orders d ON a.OrderID=d.OrderID
GO
ALTER TABLE [dbo].[AddressManager] ADD  DEFAULT ((0)) FOR [AMMark]
GO
ALTER TABLE [dbo].[BookAppraise] ADD  DEFAULT (getdate()) FOR [BADate]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [BookIsBuy]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [BookIsHot]
GO
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_BookIsDelete]  DEFAULT ((0)) FOR [BookIsDelete]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderState]  DEFAULT ((1)) FOR [OrderState]
GO
ALTER TABLE [dbo].[AddressManager]  WITH CHECK ADD  CONSTRAINT [FK_ADDRESSM_REFERENCE_USERS] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[AddressManager] CHECK CONSTRAINT [FK_ADDRESSM_REFERENCE_USERS]
GO
ALTER TABLE [dbo].[BookAppraise]  WITH CHECK ADD  CONSTRAINT [FK_BOOKAPPR_REFERENCE_ORDERDET] FOREIGN KEY([ODID])
REFERENCES [dbo].[OrderDetail] ([ODID])
GO
ALTER TABLE [dbo].[BookAppraise] CHECK CONSTRAINT [FK_BOOKAPPR_REFERENCE_ORDERDET]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_BOOKS_REFERENCE_BSCATEGO] FOREIGN KEY([BSID])
REFERENCES [dbo].[BSCategory] ([BSID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_BOOKS_REFERENCE_BSCATEGO]
GO
ALTER TABLE [dbo].[BSCategory]  WITH CHECK ADD  CONSTRAINT [FK_BSCATEGO_REFERENCE_BLCATEGO] FOREIGN KEY([BLID])
REFERENCES [dbo].[BLCategory] ([BLID])
GO
ALTER TABLE [dbo].[BSCategory] CHECK CONSTRAINT [FK_BSCATEGO_REFERENCE_BLCATEGO]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ORDERDET_REFERENCE_BOOKS] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_ORDERDET_REFERENCE_BOOKS]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_ORDERDET_REFERENCE_ORDERS] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_ORDERDET_REFERENCE_ORDERS]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_ORDERS_REFERENCE_USERS] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_ORDERS_REFERENCE_USERS]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MD5编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admins', @level2type=N'COLUMN',@level2name=N'AdminPwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-5分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BookAppraise', @level2type=N'COLUMN',@level2name=N'BAPoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规则：DDYYYYMMDD0001' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'OrderNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=待确认，2=已确认，3=已发货，4=完成' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'OrderState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MD5编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserPwd'
GO
USE [master]
GO
ALTER DATABASE [BooksDB] SET  READ_WRITE 
GO
