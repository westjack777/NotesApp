CREATE PROCEDURE [dbo].[spNotes_Get]
	@Id bigint
AS
begin
	select Id, Description
	from dbo.[Notes]
	where Id = @Id;
end
