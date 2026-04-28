using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceEventUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject ChoiceCanvas;
    [SerializeField] private TMP_Text questionTextUI;
    [SerializeField] private TMP_Text optionATextUI;
    [SerializeField] private TMP_Text optionBTextUI;
    [SerializeField] private TMP_Text optionCTextUI;
    [SerializeField] private Button buttonA;
    [SerializeField] private Button buttonB;
    [SerializeField] private Button buttonC;

    // This is the reference to your ScriptableObject
    private ChoiceData currentData; 

    // 1. Setup now takes the whole object
    public void SetupChoice(ChoiceData data)
    {
        currentData = data; // CRITICAL: This was likely null or missing

        if (optionATextUI != null) optionATextUI.text = data.optionA;
        if (optionBTextUI != null) optionBTextUI.text = data.optionB;
        if (optionCTextUI != null) optionCTextUI.text = data.optionC;
        if(questionTextUI != null) questionTextUI.text = data.question;
        
        SetButtonsInteractable(true);
    }

    public void SelectOptionA() => SendChoice(0, currentData.optionA);
    public void SelectOptionB() => SendChoice(1, currentData.optionB);
    public void SelectOptionC() => SendChoice(2, currentData.optionC);

    private void SendChoice(int selectedOption, string selectedText)
{
    Debug.Log("BUTTON CLICKED");
    SetButtonsInteractable(false);

    if (currentData == null) 
    {
        Debug.LogError("ChoiceData is missing!");
        return;
    }

    ChoiceRequest request = new ChoiceRequest
    {
        userId = SessionManager.Instance.UserId,
        eventId = currentData.eventId,
        selectedOption = selectedOption,
        selectedText = selectedText
    };

    ChoiceApiManager.Instance.SendChoice(request, (success) => 
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
    });
    CloseCanvas();
}

    private void SetButtonsInteractable(bool state)
    {
        if (buttonA != null) buttonA.interactable = state;
        if (buttonB != null) buttonB.interactable = state;
        if (buttonC != null) buttonC.interactable = state;
    }

    private void CloseCanvas()
    {
        ChoiceCanvas.SetActive(false);
    }

}