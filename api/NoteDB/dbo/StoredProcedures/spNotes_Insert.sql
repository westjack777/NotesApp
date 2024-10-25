CREATE PROCEDURE [dbo].[spNotes_Insert]
	@Description nvarchar(MAX)
AS
begin
	insert into dbo.[Notes] (Description)
	values (@Description);
end