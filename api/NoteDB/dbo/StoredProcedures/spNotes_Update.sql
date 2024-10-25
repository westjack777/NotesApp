CREATE PROCEDURE [dbo].[spNotes_Update]
	@Id bigint,
	@Description nvarchar(MAX)
AS
begin
	update dbo.[Notes]
	set Description = @Description
	where Id = @Id;
end