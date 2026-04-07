using Microsoft.AspNetCore.Mvc;
using Npgsql;
using VrChoiceApi.Models;

namespace VrChoiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoicesController : ControllerBase
    {
        private readonly string _connectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=Talib123!;Database=UnityVRDecisionSave";

        [HttpPost]
        public async Task<IActionResult> SaveChoice([FromBody] ChoiceDto dto)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            string sql = @"
                INSERT INTO user_choices (user_id, event_id, selected_option, selected_text)
                VALUES (@userId, @eventId, @selectedOption, @selectedText)
                ON CONFLICT (user_id, event_id)
                DO UPDATE SET
                    selected_option = EXCLUDED.selected_option,
                    selected_text = EXCLUDED.selected_text,
                    created_at = NOW();";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("userId", dto.UserId);
            cmd.Parameters.AddWithValue("eventId", dto.EventId);
            cmd.Parameters.AddWithValue("selectedOption", dto.SelectedOption);
            cmd.Parameters.AddWithValue("selectedText", dto.SelectedText);

            await cmd.ExecuteNonQueryAsync();

            return Ok(new { message = "Choice saved" });
        }

        [HttpGet("{userId}/{eventId}")]
        public async Task<IActionResult> GetChoice(string userId, string eventId)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            string sql = @"
        SELECT user_id, event_id, selected_option, selected_text, created_at
        FROM user_choices
        WHERE user_id = @userId AND event_id = @eventId;";

            await using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("userId", userId);
            cmd.Parameters.AddWithValue("eventId", eventId);

            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return NotFound();

            var result = new
            {
                userId = reader.GetString(0),
                eventId = reader.GetString(1),
                selectedOption = reader.GetInt32(2),
                selectedText = reader.GetString(3),
                createdAt = reader.GetDateTime(4)
            };

            return Ok(result);
        }
    }
}
