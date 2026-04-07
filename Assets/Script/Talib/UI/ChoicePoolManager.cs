using UnityEngine;

public class ChoicePoolManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ChoiceEventUI choiceEventUI;
    [SerializeField] private GameObject choiceUI;

    [Header("Choice Pool")]
    [SerializeField] private ChoiceData[] choices;

    private int currentChoiceIndex = 0;

    public void ShowCurrentChoice()
{
    if (choices == null || choices.Length == 0)
    {
        Debug.LogWarning("Choice pool boş.");
        return;
    }

    if (currentChoiceIndex < 0 || currentChoiceIndex >= choices.Length)
    {
        Debug.Log("Geçerli seçim kalmadı.");
        return;
    }

    ChoiceData currentChoice = choices[currentChoiceIndex];

    choiceEventUI.SetupChoice(currentChoice); 

    choiceUI.SetActive(true);
}

    public void GoToNextChoice()
    {
        currentChoiceIndex++;

        if (currentChoiceIndex >= choices.Length)
        {
            Debug.Log("Tüm seçimler tamamlandı.");
            return;
        }

        ShowCurrentChoice();
    }

    public void ResetChoices()
    {
        currentChoiceIndex = 0;
    }

    public int GetCurrentChoiceIndex()
    {
        return currentChoiceIndex;
    }
}