using UnityEngine;

public class ChoiceEventUI : MonoBehaviour
{
    [Header("Current Event")]
    public string currentUserId = "user_001";
    public string currentEventId;
    public string optionAText;
    public string optionBText;

    public void SetupChoice(string userId, string eventId, string optionA, string optionB)
    {
        currentUserId = userId;
        currentEventId = eventId;
        optionAText = optionA;
        optionBText = optionB;
    }

    public void SelectOptionA()
    {
        SendChoice(0, optionAText);
    }

    public void SelectOptionB()
    {
        SendChoice(1, optionBText);
    }

    private void SendChoice(int selectedOption, string selectedText)
    {
        ChoiceRequest request = new ChoiceRequest
        {
            userId = currentUserId,
            eventId = currentEventId,
            selectedOption = selectedOption,
            selectedText = selectedText
        };

        StartCoroutine(ChoiceApiManager.Instance.SendChoice(request));
    }
}