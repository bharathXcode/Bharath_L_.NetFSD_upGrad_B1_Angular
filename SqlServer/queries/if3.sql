declare @marks int
set @marks=45
if @marks>=75
print 'distinction'
else if @marks>=60
print 'first class'
else if @marks>=50
print 'second class'
else
print 'fail'
