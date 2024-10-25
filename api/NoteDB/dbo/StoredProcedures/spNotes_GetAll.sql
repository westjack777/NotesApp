CREATE PROCEDURE [dbo].[spNotes_GetAll]
AS
begin
	select Id, Description
	from dbo.[Notes];
end
