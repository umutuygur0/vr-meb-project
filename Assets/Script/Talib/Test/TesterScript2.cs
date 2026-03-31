using UnityEngine;

public class TesterScript2 : MonoBehaviour
{
   public void startAfterTester1()
    {
        FindObjectOfType<ChoicePoolManager>().GoToNextChoice();
    }
}
