create trigger delete_position on Position
after delete as
BEGIN
declare @id int
select @id=ID from deleted
delete from Employee where PositionID=@id
END