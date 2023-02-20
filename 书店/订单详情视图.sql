--确定数据源
--drop view view_orders
GO
create view view_orders
as
select OrderID,OrderNum,UserNick,UserName,OrderMoney,OrderState,OrderDate,AMTel,AMUser,AMAddress
 from Orders  o
inner join Users u
on o.UserID=u.UserID 
inner join AddressManager a
on a.AMID=o.AMID
GO
select * from view_orders