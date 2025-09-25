using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using AlternativeGardener.Models;
using AlternativeGardener.Services.Interfaces;

namespace AlternativeGardener.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class RecordController : Controller
    {

        private readonly IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet("/allrecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            var records = await _recordService.GetAllRecords();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(int id)
        { 
            var record = await _recordService.GetRecordById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecord([FromBody] Record newRecord)
        {
            if (newRecord == null)
            {
                return BadRequest();
            }
            var createdRecord = await _recordService.CreateRecord(newRecord);
            return CreatedAtAction(nameof(GetRecordById), new { id = createdRecord.RecordId }, createdRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecord(int id, [FromBody] Record updatedRecord)
        {
            if (updatedRecord == null || id != updatedRecord.RecordId)
            {
                return BadRequest();
            }
            var record = await _recordService.UpdateRecord(id, updatedRecord);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var success = await _recordService.DeleteRecord(id);
            return success ? NoContent() : NotFound();
        }
    }
}
