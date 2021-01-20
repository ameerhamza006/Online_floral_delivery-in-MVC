create database  floral_delivery

use floral_delivery

create table product(
id int primary key identity,
[product name] varchar(50) ,
[price] numeric (25) ,
[product image] varchar(max) ,
[product category id] int foreign key references category([category id])
)


create table category(
[category id]int primary key identity,
[category name] varchar(50)
)

create table registeration(
cus_id int primary key identity,
F_name varchar(50),
L_name varchar(50),
Dob Date,
Email nvarchar(50),
P_No numeric,
password nvarchar(50),  --<<<-New column -------
Address nvarchar(100)
)
-----------------New table ----------------->
create table cart
(
cart_id int primary key identity,
cart_qty int,
cart_fk_reg int foreign key references registeration(cus_id),
cart_fk_pro int foreign key references product(id),
)
------------------------------------------------>
create table contact(
Id int primary key identity,
FullName varchar(50),
email nvarchar(50),
subj varchar(100),
msg varchar(max)
)
select * from registeration
select * from contact