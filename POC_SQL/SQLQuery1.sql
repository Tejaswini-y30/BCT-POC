USE POCecommercesite
GO
CREATE TABLE tblSeller
(
	SellerID  VARCHAR(10) NOT NULL,
	SellerPassword VARCHAR(10) NOT NULL,
	SellerName VARCHAR(20) NOT NULL,
	SellerEmail varchar(255) NOT NULL,
	PRIMARY KEY (SellerID)
);
GO
CREATE TABLE tblCategory
(
	CategoryID VARCHAR(10),
	CatergoryName VARCHAR(20),
	SellerID  VARCHAR(10) NOT NULL,
	FOREIGN KEY (SellerID) REFERENCES tblSeller(SellerID),	
	PRIMARY KEY (CategoryID)
);

CREATE TABLE tblProduct
(
	ProductID VARCHAR(10) NOT NULL,
	CategoryID VARCHAR(10),
	ProductColor VARCHAR(15) NOT NULL,
	ProductSize VARCHAR(10) NOT NULL,
	Cost DECIMAL(5) NOT NULL,
	Quantity DECIMAL(5) NOT NULL,
	SellerID VARCHAR(10) NOT NULL,
	ProductDescription       text,
	CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, 
	ModifiedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (ProductID),
	FOREIGN KEY (SellerID) REFERENCES tblSeller(SellerID) ,
	FOREIGN KEY (CategoryID) REFERENCES tblCategory(CategoryID) ,
);

CREATE TABLE tblUser
(
	UserID VARCHAR(10) PRIMARY KEY,
	Email varchar(255)    NOT NULL,
	UserPassword VARCHAR(20) NOT NULL,
	Firstname varchar(20)    NOT NULL,
	Lastname varchar(20)    NOT NULL,
	Active BIT DEFAULT 1,
);


CREATE TABLE tblShippingDetails
(
	ShippingDetailID VARCHAR(10) PRIMARY KEY,
	UserID VARCHAR(10) NOT NULL,
	UAddress VARCHAR (500) NULL,
	UCity VARCHAR (500) NULL,
	UState VARCHAR (500) NULL,
	UCountry VARCHAR (50) NULL,
	UZipCode VARCHAR (50) NULL,
	ProductID VARCHAR(10),
	AmountPaid DECIMAL(18, 0) NULL,
	PaymentType VARCHAR(50) NULL,
	FOREIGN KEY (UserID) REFERENCES tblUser(UserID),
	FOREIGN KEY (ProductID) REFERENCES tblProduct(ProductID),
);


CREATE TABLE tblCart
(
	Quantity_wished DECIMAL(5) NOT NULL,
	Date_Added DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	CartID VARCHAR(10) NOT NULL,
	UserID VARCHAR(10) NOT NULL,
	ProductID VARCHAR(10) NOT NULL,
	Purchased VARCHAR(3) default 'NO',
	FOREIGN KEY (ProductID) REFERENCES tblProduct(ProductID),
	FOREIGN KEY (UserID) REFERENCES tblUser(UserID),
    Primary key(CartID,ProductID)
);

alter table tblSeller add Active BIT DEFAULT 1;

------------SET ONE---------------

INSERT INTO tblseller (SellerID, SellerPassword, SellerName, SellerEmail)
VALUES ('sell100','3456', 'Apple','ios.apple@gmail.com')

INSERT INTO tblCategory (CategoryID , CatergoryName , SellerID )
 VALUES('cate210','earphones','sell100');

INSERT INTO tblProduct (ProductID, CategoryID, ProductColor, ProductSize, Cost, Quantity, SellerID, ProductDescription)
 VALUES('pro123','cate210',	'black','Small', 599,50 ,'sell100','experice music like never before with apple- black earphones with type c cable');

INSERT INTO tblUser (UserID, Email, UserPassword, Firstname, Lastname)
VALUES('user001','user1@gmail.com', 'user1','ABC','PQR');

INSERT INTO tblShippingDetails (ShippingDetailID , UserID, UAddress, UCity,  UState, UCountry, UZipCode, ProductID, AmountPaid , PaymentType) 
VALUES('ship101','user001','A-4 Rose villa gandhinagar','Kholapur','Maharashtra', 'India','411023','pro123',599,'Credit Card');

INSERT INTO tblCart (Quantity_wished, CartID, UserID, ProductID, Purchased)
VALUES(1,'cart601','user001','pro123','YES');


------------SET TWO---------------


INSERT INTO tblseller (SellerID, SellerPassword, SellerName, SellerEmail)
VALUES ('sell210','0987', 'Boat','boatrockers@gmail.com')

INSERT INTO tblCategory (CategoryID , CatergoryName , SellerID )
 VALUES('cate300','Earphones','sell210');

INSERT INTO tblProduct (ProductID, CategoryID, ProductColor, ProductSize, Cost, Quantity, SellerID, ProductDescription)
 VALUES('pro400','cate300',	'blue','big', 299,30 ,'sell210','welcome to nirvana - boat rockers');

INSERT INTO tblUser (UserID, Email, UserPassword, Firstname, Lastname)
VALUES('user002','user2@gmail.com', 'user2','DEF','GHI');

INSERT INTO tblShippingDetails (ShippingDetailID , UserID, UAddress, UCity,  UState, UCountry, UZipCode, ProductID, AmountPaid , PaymentType) 
VALUES('ship202','user002','B-212 sai park','Sangli','Maharashtra', 'India','411020','pro400',599,'Credit Card');

INSERT INTO tblCart (Quantity_wished, CartID, UserID, ProductID)
VALUES(2,'cart404','user002','pro400');

INSERT INTO tblCart (Quantity_wished, CartID, UserID, ProductID, Purchased)
VALUES(2,'cart402','user002','pro123','yes');

INSERT INTO tblCart (Quantity_wished, CartID, UserID, ProductID)
VALUES(1,'cart401','user002','pro000');

INSERT INTO tblProduct (ProductID, CategoryID, ProductColor, ProductSize, Cost, Quantity, SellerID, ProductDescription)
 VALUES('pro000','cate210',	'White','medium', 499,30 ,'sell100','experice music like never before with apple- black earphones with type c cable');

INSERT INTO tblUser (UserID, Email, UserPassword, Firstname, Lastname)
VALUES('user003','user3@gmail.com', 'user3','TTT','YYY');


select * from tblseller;
select * from tblUser;
select * from tblProduct;
select * from tblCategory;
select * from tblCart;
select * from tblShippingDetails;

-----------If the customer wants to see details of product present in the cart
select * from tblProduct where ProductID in(
        select ProductID from tblCart where (CartID in (
            select CartID from tblUser where UserID='user001'
        ))
    and purchased='NO');

------------- purchased products
select ProductID,Quantity_wished from tblCart where (purchased='yes' );

-----------------------How much product sold on the particular date
 select count(ProductID) count_pid,Date_Added from tblCart where purchased='yes'  group by(date_added);


 -----------------------If a customer want to know the total price present in the cart
  select sum(quantity_wished * cost) total_payable from tblProduct p join tblCart c on p.ProductID=c.ProductID where c.ProductID in (select ProductID from tblCart where cartID in(select CartID from tblUser where UserID='user002') and purchased='yes');

  ---------------Show the details of the customer who has not purchased any thing
  Select * from tblUser where UserID not in (select UserID from tblShippingDetails);



go 

create trigger trUser
	on tblUser
	instead of delete, insert, update
	as
	begin
	set nocount ON
	end
set nocount on
select * from tblUser
set nocount off
INSERT INTO tblUser (UserID, Email, UserPassword, Firstname, Lastname)
VALUES('user004','user4@gmail.com', 'user4','QWE','RTY');

go

SELECT * from tblUser

go

create trigger trCategory
	on tblCategory
	instead of delete
	as
	begin
	select *,'tblCategory' from deleted
	end

	delete from tblCategory where CategoryID='cate300';

GO
