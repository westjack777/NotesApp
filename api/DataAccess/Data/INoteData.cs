using DataAccess.Models;

namespace DataAccess.Data;
public interface INoteData
{
    Task DeleteNote(int id);
    Task<NoteModel?> GetNote(int id);
    Task<IEnumerable<NoteModel>> GetNotes();
    Task InsertNote(NoteModel note);
    Task UpdateNote(NoteModel note);
}