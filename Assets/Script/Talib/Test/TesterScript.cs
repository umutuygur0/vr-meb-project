using UnityEngine;

public class TesterScript : MonoBehaviour
{
    [SerializeField] private TesterScript2 testerScript2;
    void Start()
    {
       FindObjectOfType<ChoicePoolManager>().ShowCurrentChoice(); 
    }

    public void onNextChoice()
    {
        testerScript2.startAfterTester1();
    }
}
