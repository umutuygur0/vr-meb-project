using UnityEngine;
using TMPro;

public class ChoiceEventUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text optionATextUI;
    [SerializeField] private TMP_Text optionBTextUI;

    private string currentEventId;
    private string optionAText;
    private string optionBText;

    public void SetupChoice(string eventId, string optionA, string optionB)
    {
        currentEventId = eventId;
        optionAText = optionA;
        optionBText = optionB;

        if (optionATextUI != null) optionATextUI.text = optionAText;
        if (optionBTextUI != null) optionBTextUI.text = optionBText;
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
            userId = GetUserId(),
            eventId = currentEventId,
            selectedOption = selectedOption,
            selectedText = selectedText
        };

        StartCoroutine(ChoiceApiManager.Instance.SendChoice(request));
    }

    private string GetUserId()
    {
        if (!PlayerPrefs.HasKey("userId"))
        {
            string newId = System.Guid.NewGuid().ToString();
            PlayerPrefs.SetString("userId", newId);
        }

        return PlayerPrefs.GetString("userId");
    }
}