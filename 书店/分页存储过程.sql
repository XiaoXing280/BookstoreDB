drop proc proc_page

CREATE proc proc_page
@pageIndex int=1,--ҳ����
@pageSize int=10,--ҳ��С
@tableName varchar(100),--����
@keyName varchar(100),--������
@filter varchar(1000)='*',--��ѯ�ֶ�
@where varchar(1000)='',--where����
@order varchar(1000)='',--��������
@dataCount int output--�ܼ�¼�����������
as

declare @sql nvarchar(2000)--����nvarchar
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

if(@pageIndex=1)--��һҳ
begin
	set @sql='select top '+convert(varchar(15),@pageSize)+' '+@filter
					+' from '+@tableName+@where1+@order1
end
else--����ҳ
begin
	set @sql = 'select top '+convert(varchar(15),@pageSize)
					  +' '+@filter+' from '+@tableName+'
						where '+@keyName+' not in
						(select top '+convert(varchar(15),(@pageIndex-1)*@pageSize)
						+' '+@keyName+' from '
						+@tableName+@where1+@order1+') '
						+@where2+@order1
end
--ִ���ַ�����SQL����
exec(@sql)
--��ѯ��ȡ�ܼ�¼��
set @sql='select @count=count(*) from '+@tableName+@where1
--ִ�д��������ַ���SQL����
exec sp_executesql @sql,N'@count int output',@count=@dataCount output



declare @count int
exec proc_page @pageIndex=2,@pageSize=5
,@tableName='View_Books',@keyName='BookID'
,@where='',@order='BookID desc'
,@filter='BookID,BLName,BSName,BookTitle,BookPublish,BookMoney,BookPrice,BookSale,BookDeport,BookIsBuy,BookIsHot,BSID'
,@dataCount=@count output
select @count