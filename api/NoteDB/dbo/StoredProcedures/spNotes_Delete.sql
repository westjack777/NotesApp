CREATE PROCEDURE [dbo].[spNotes_Delete]
	@Id bigint
AS
begin
	delete
	from dbo.[Notes]
	where Id = @Id;
end
