SELECT * FROM dbo.Orders
go
CREATE  FUNCTION   BuildNum() RETURNS varchar(100)
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

--执行自定义函数（必须使用dbo.函数名调用）
SELECT dbo.BuildNum()
--在增删改查中使用自定义函数
INSERT INTO dbo.Orders( UserID ,AMID , OrderNum ,OrderDate , OrderState ,OrderMoney)
VALUES  ( 1 ,1 ,dbo.BuildNum() , GETDATE() ,0 ,NULL )


