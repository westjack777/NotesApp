namespace MinimalNote;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/GetNotes", GetNotes);
        app.MapPost("/AddNotes", InsertNote);
        app.MapDelete("/DeleteNotes", DeleteNote);
    }

    private static async Task<IResult> GetNotes(INoteData data)
    {
        try
        {
            return Results.Ok(await data.GetNotes());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetNote(int id, INoteData data)
    {
        try
        {
            var results = await data.GetNote(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertNote(NoteModel note, INoteData data)
    {
        try
        {
            await data.InsertNote(note);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateNote(NoteModel note, INoteData data)
    {
        try
        {
            await data.UpdateNote(note);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteNote(int id, INoteData data)
    {
        try
        {
            await data.DeleteNote(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}