using UnityEngine;

public class ChoiceButtonHandler : MonoBehaviour
{
    public void SelectOptionA()
    {
        ChoiceRequest request = new ChoiceRequest
        {
            userId = "user_001",
            eventId = "event_02",
            selectedOption = 0,
            selectedText = "Seçenek A"
        };

        StartCoroutine(ChoiceApiManager.Instance.SendChoice(request));
    }

    public void SelectOptionB()
    {
        ChoiceRequest request = new ChoiceRequest
        {
            userId = "user_001",
            eventId = "event_02",
            selectedOption = 1,
            selectedText = "Seçenek B"
        };

        StartCoroutine(ChoiceApiManager.Instance.SendChoice(request));
    }
}