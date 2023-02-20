use BooksDB
GO
select BLID,BLName from  BLCategory 
insert into BLCategory(BLName)
values('1'),('2'),('3'),('4'),('5'),('6')

select BSID,BLName,BSName from  BsCategory,BLCategory where BsCategory.BLID=BLCategory.BLID
insert into BsCategory(BLID,BSName)
values(12,'1'),(14,'2'),(14,'3'),(13,'4')
select BLID,BLName from  BLCategory

select BookID,BSName,BLName,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,
BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot, BookIsDelete,
BookBuyDate,BookHotDate  from Books,BsCategory,BLCategory where Books.BSID = BsCategory.BSID and BsCategory.BLID=BLCategory.BLID 

select top 5 * from Books where BookIsBuy=1 order by BookID
select top 10 * from Books where BookIsHot=1 order by BookID
select top 5 * from Books  

select BookTitle,ODPrice,ODCount,ODMoney from OrderDetail,Books where OrderDetail.BookID=Books.BookID

select OrderID,UserNick,OrderNum,OrderDate,OrderState,OrderMoney from Orders,Users where Orders.UserID=Users.UserID

select * from Users  
insert into Users(UserName,UserPwd,UserEmail,UserSex,UserNick)
values('11','1111111','11@11.11','ÄÐ','ÀîËÄ')

select * from AddressManager
insert into AddressManager(UserID,AMUser,AMTel,AMAddress,AMMark)
values(3,'asd','123456777','123456777asd',1)

select * from BookAppraise