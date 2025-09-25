using AlternativeGardener.Models;

namespace AlternativeGardener.Services.Interfaces
{
    public interface IRecordService
    {
        Task<List<Record>> GetAllRecords();
        Task<Record?> GetRecordById(int id);
        Task<Record> CreateRecord(Record newRecord);
        Task<Record?> UpdateRecord(int id, Record updatedRecord);
        Task<bool> DeleteRecord(int id);
    }
}
