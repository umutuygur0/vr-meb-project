using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [SerializeField] private ActionSequence actionSequence;
    public GameObject exclamationMark;
    public GameObject gameplayRoot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exclamationMark.SetActive(false);
            gameplayRoot.SetActive(true);
            actionSequence.StartSequence();
        }
    }
}
