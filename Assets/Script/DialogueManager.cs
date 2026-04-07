using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Bubbles")]
    public GameObject[] speechBubbles;

    [Header("Timing")]
    public float visibleTime = 5f;
    public float delayBetweenBubbles = 1f;

    [Header("Events")]
    // This event allows you to plug in the ActionSequence.Advance in the Editor
    public UnityEvent onDialogueComplete;
    
    private bool hasStarted = false;

    public void StartDialogue()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            StartCoroutine(PlayDialogues());
        }
    }

    IEnumerator PlayDialogues()
    {
        foreach (var bubble in speechBubbles)
        {
            bubble.SetActive(true);

            yield return new WaitForSeconds(visibleTime);

            bubble.SetActive(false);

            yield return new WaitForSeconds(delayBetweenBubbles);
        }
        hasStarted = false;
        
        onDialogueComplete?.Invoke();
    }
}