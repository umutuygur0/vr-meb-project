using System;
using UnityEngine;

public class ChoiceUI : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject policeGoodPrefab;
    public GameObject policeBadPrefab;
    public Transform policeSpawnPoint;

    public Action OnPoliceSpawned;

    public void ShowChoices()
    {
        choicePanel.SetActive(true);
    }

    public void SpawnGoodPolice()
    {
        SpawnPolice(true);
    }

    public void SpawnBadPolice()
    {
        SpawnPolice(false);
    }

    private void SpawnPolice(bool isGoodChoice)
    {
        GameObject police = Instantiate(
            isGoodChoice ? policeGoodPrefab : policeBadPrefab,
            policeSpawnPoint.position,
            Quaternion.identity
        );

        police.SetActive(true);

        OnPoliceSpawned?.Invoke();
    }
}