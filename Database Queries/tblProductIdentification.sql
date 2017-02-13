
create table tblProductIdentification(
product_id nchar(10) not null foreign key references tblProductMaster(product_id),
batch_number varchar(50) not null,
expiry date not null,
identity_no varchar(max) not null
primary key (product_id, batch_number,expiry))


create table tblInStock(
identity_no varchar(100) not null primary key,
product_id nchar(10) not null foreign key references tblProductMaster(product_id),
mfg_by varchar(max),
quantity int not null,
created_date_time datetime not null,
modified_date_time datetime)



 