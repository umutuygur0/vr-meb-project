using UnityEngine;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject policeGoodPrefab;
    public GameObject policeBadPrefab;
    public Transform policeSpawnPoint;

    public GameObject messageCanvas; // Canvas içindeki yazı objesi
    public float policeWalkTime = 3f;

    public void ShowChoices()
    {
        choicePanel.SetActive(true);
    }

    public void OnStopBullying()
    {
        choicePanel.SetActive(false);
        StartCoroutine(SpawnPoliceSequence(true));
    }

    public void OnSupportBullying()
    {
        choicePanel.SetActive(false);
        StartCoroutine(SpawnPoliceSequence(false));
    }

    System.Collections.IEnumerator SpawnPoliceSequence(bool isGoodChoice)
    {
        GameObject police = Instantiate(
            isGoodChoice ? policeGoodPrefab : policeBadPrefab,
            policeSpawnPoint.position,
            Quaternion.identity
        );

        // Polisin yürüyüş süresini bekle
        yield return new WaitForSeconds(policeWalkTime);

        // Canvas'ı aktif et
        messageCanvas.SetActive(true);

        yield return new WaitForSeconds(3f);

        // Canvas'ı kapat
        messageCanvas.SetActive(false);
    }
}
