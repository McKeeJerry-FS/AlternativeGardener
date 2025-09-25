using AlternativeGardener.Data;
using AlternativeGardener.Models;
using AlternativeGardener.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AlternativeGardener.Services
{
    public class RecordService : IRecordService

    {
        private readonly ApplicationDbContext _context;
        public readonly UserManager<AppUser> _userManager;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public RecordService(ApplicationDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task<AppUser?> GetCurrentUserAsync()
        {
            var httpCtx = _httpContextAccessor.HttpContext;
            if (httpCtx == null)
            {
                return await Task.FromResult<AppUser?>(null);
            }

            return await _userManager.GetUserAsync(httpCtx.User);
        }

        public Task<Record> CreateRecord(Record newRecord)
        {
            var user = GetCurrentUserAsync().Result;
            if (user == null)
            {
                throw new Exception("User not found");
            }
            newRecord.UserId = user.Id;
            _context.Records.Add(newRecord);
            _context.SaveChanges();
            return Task.FromResult(newRecord);
        }

        public async Task<bool> DeleteRecord(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return false;
            }
            var record = _context.Records
                .FirstOrDefault(r => r.RecordId == id && r.UserId == user.Id);
            if (record == null)
            {
                return false;
            }
            _context.Records.Remove(record);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Record>> GetAllRecords()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return new List<Record>();
            }
            var records = _context.Records
                .Where(r => r.UserId == user.Id)
                .ToList();
            return records;
        }

        public async Task<Record?> GetRecordById(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }
            var record = _context.Records
                .FirstOrDefault(r => r.RecordId == id && r.UserId == user.Id);
            return record;
        }

        public Task<Record?> UpdateRecord(int id, Record updatedRecord)
        {
            var user = GetCurrentUserAsync().Result;
            if (user == null)
            {
                return Task.FromResult<Record?>(null);
            }
            var record = _context.Records
                .FirstOrDefault(r => r.RecordId == id && r.UserId == user.Id);
            if (record == null)
                {
                return Task.FromResult<Record?>(null);
            }
            record.Date = updatedRecord.Date;
            record.Notes = updatedRecord.Notes;
            _context.Records.Update(record);
            _context.SaveChanges();
            return Task.FromResult<Record?>(record);

        }

        

    }
}
