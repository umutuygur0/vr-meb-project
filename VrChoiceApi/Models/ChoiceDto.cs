namespace VrChoiceApi.Models
{
    public class ChoiceDto
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
        public int SelectedOption { get; set; }
        public string SelectedText { get; set; }
    }
}