create database bankDb
use bankDb
create table Customers(
CustomerId int primary key Identity(1,1),
FirstName varchar(20) not null,
LastName varchar(20) not null,
DateOfBirth Date not null,
Gender char(1) check(Gender in('M','F')),
Phone varchar(15) unique not null,
Email varchar(40) unique null,
City varchar(50),
CreateDate DateTime Default getdate()
)
create table Branches(
BranchId int Primary key Identity(1000,1),
BranchName varchar(100) not null,
IFSCCode varchar(20) unique not null,
City varchar(30) not null,
State varchar(50) not null
)
create table Accounts(
AccountId int primary key Identity(10000,1),
AccountNumber varchar(20) unique not null,
CustomerId int not null,
BranchId int not null,
AccountType varchar(30) check(AccountType in('Savings','Current')),
Balance decimal(15,2) default 0 check(Balance>=0),
OpenDate Datetime default getdate()
constraint Fk_Accounts_customers Foreign key(CustomerId) References Customers(CustomerId),
foreign key(BranchId) references Branches(BranchId)
)
create table Transactions(
TransactionId int primary key Identity(1,1),
AccountId int not null,
TransactionType varchar(30) check(TransactionType in('Credit','Debit')),
Amount Decimal(15,2) not null check(Amount>0),
TransactionDate Datetime default getdate(),
Description varchar(300),
constraint Fk_Transactions_Account foreign key(AccountId) references Accounts(AccountID)
)
create table Loans(
LoanId int primary key identity(1,1),
CustomerId int not null,
BranchId int not null,
LoanAmount decimal(15,2) check(LoanAmount>0),
LoanType Varchar(50),
StartDate Date,
Status varchar(20) default 'active',
constraint Fk_Loans_customers Foreign key(CustomerId) References Customers(CustomerId),
constraint Fk_Loans_Branches foreign key(BranchId) references Branches(BranchId)

)