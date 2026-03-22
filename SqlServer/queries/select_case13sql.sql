select AccountId,
AccountNumber,
case
when Balance>50000 then 'Excellent'
when Balance>20000 then 'Sufficient'
when Balance>=15000 then 'low balance'
when balance<15000 then 'need to take the action'
end as 'Status' from Accounts
select * from Accounts