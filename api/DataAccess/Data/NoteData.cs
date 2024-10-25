using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class NoteData : INoteData
{
    private readonly ISqlDataAccess _db;

    public NoteData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<NoteModel>> GetNotes() =>
        _db.LoadData<NoteModel, dynamic>("dbo.spNotes_GetAll", new { });

    public async Task<NoteModel?> GetNote(int id)
    {
        var results = await _db.LoadData<NoteModel, dynamic>(
            "dbo.spNotes_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertNote(NoteModel note) =>
        _db.SaveData("dbo.spNotes_Insert", new { note.Description });

    public Task UpdateNote(NoteModel note) =>
        _db.SaveData("dbo.spNotes_Update", note);

    public Task DeleteNote(int id) =>
        _db.SaveData("dbo.spNotes_Delete", new { Id = id });
}
