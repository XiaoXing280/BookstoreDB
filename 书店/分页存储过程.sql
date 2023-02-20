drop proc proc_page

CREATE proc proc_page
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
	set @sql='select top '+convert(varchar(15),@pageSize)+' '+@filter
					+' from '+@tableName+@where1+@order1
end
else--其他页
begin
	set @sql = 'select top '+convert(varchar(15),@pageSize)
					  +' '+@filter+' from '+@tableName+'
						where '+@keyName+' not in
						(select top '+convert(varchar(15),(@pageIndex-1)*@pageSize)
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



declare @count int
exec proc_page @pageIndex=2,@pageSize=5
,@tableName='View_Books',@keyName='BookID'
,@where='',@order='BookID desc'
,@filter='BookID,BLName,BSName,BookTitle,BookPublish,BookMoney,BookPrice,BookSale,BookDeport,BookIsBuy,BookIsHot,BSID'
,@dataCount=@count output
select @count