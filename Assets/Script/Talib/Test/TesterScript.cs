using UnityEngine;

public class TesterScript : MonoBehaviour
{
    [SerializeField] private ActionSequence actionSequence;

    private void Start()
    {
        Debug.Log("Tester: Starting Sequence...");
        actionSequence.StartSequence();
    }
}