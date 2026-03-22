--Alter used to chage the schema or structure of the table
alter table customers add AadharNumber varchar(12)
alter table accounts add Isactive bit default 1
--change datetype or size
alter table customers alter column Phone varchar(20)
--add constraint
alter table Loans add constraint cK_loans_status
check(Status in('Active','Closed','Pending'))
--drop constraint
alter table loans drop constraint cK_loans_status
--add fk
alter table transactions
add constraint Fk_Transactions_Accounts
foreign key(AccountId) references Accounts(AccountId)
--drop column
alter table Customers drop column AadharNumber
