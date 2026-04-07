using UnityEngine;
using UnityEngine.Events;

public class TesterScript2 : MonoBehaviour
{
    [SerializeField] private UnityEvent onTestComplete;

    public void PrepareNextChoice()
    {
        Debug.Log("Tester 2: Moving Pool Manager to next index...");
        
        // Tell the manager to increment index
        ChoicePoolManager manager = FindObjectOfType<ChoicePoolManager>();
        if (manager != null)
        {
            manager.GoToNextChoice(); //
        }

        onTestComplete?.Invoke();
    }
}