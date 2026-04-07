using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceEventUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text optionATextUI;
    [SerializeField] private TMP_Text optionBTextUI;
    [SerializeField] private Button buttonA;
    [SerializeField] private Button buttonB;

    // This is the reference to your ScriptableObject
    private ChoiceData currentData; 

    // 1. Setup now takes the whole object
    public void SetupChoice(ChoiceData data)
    {
        currentData = data; // CRITICAL: This was likely null or missing

        if (optionATextUI != null) optionATextUI.text = data.optionA;
        if (optionBTextUI != null) optionBTextUI.text = data.optionB;
        
        SetButtonsInteractable(true);
    }

    public void SelectOptionA() => SendChoice(0, currentData.optionA);
    public void SelectOptionB() => SendChoice(1, currentData.optionB);

    private void SendChoice(int selectedOption, string selectedText)
{
    SetButtonsInteractable(false);

    if (currentData == null) 
    {
        Debug.LogError("ChoiceData is missing!");
        return;
    }

    ChoiceRequest request = new ChoiceRequest
    {
        userId = GetUserId(),
        eventId = currentData.eventId,
        selectedOption = selectedOption,
        selectedText = selectedText
    };

    ChoiceApiManager.Instance.StartCoroutine(ChoiceApiManager.Instance.SendChoice(request, (success) => 
    {
        if (success)
        {
            ActionSequence sequence = FindObjectOfType<ActionSequence>();
            if (sequence != null)
            {
                sequence.Advance(); 
            }

            this.gameObject.SetActive(false); 
        }
        else
        {
            SetButtonsInteractable(true);
        }
    }));
}

    private void SetButtonsInteractable(bool state)
    {
        if (buttonA != null) buttonA.interactable = state;
        if (buttonB != null) buttonB.interactable = state;
    }

    private string GetUserId()
    {
        if (!PlayerPrefs.HasKey("userId"))
            PlayerPrefs.SetString("userId", System.Guid.NewGuid().ToString());
        return PlayerPrefs.GetString("userId");
    }
}