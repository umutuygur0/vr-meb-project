using UnityEngine;

[CreateAssetMenu(fileName = "NewChoice", menuName = "Choice Data")]
public class ChoiceData : ScriptableObject 
{
    public string eventId;

    [TextArea(2,5)] public string question;
    [TextArea(2, 5)] public string optionA;
    [TextArea(2, 5)] public string optionB;
    [TextArea(2, 5)] public string optionC;
}