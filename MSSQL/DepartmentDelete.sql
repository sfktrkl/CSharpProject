create trigger delete_department on Department
after delete as
BEGIN
declare @id int
select @id=ID from deleted
delete from Employee where ID=@id
delete from Position where ID=@id
END