create trigger delete_employee on Employee
after delete as
BEGIN
declare @id int
select @id=ID from deleted
delete from Task where EmployeeID=@id
delete from Salary where EmployeeID=@id
delete from Permission where EmployeeID=@id
END