using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupDialogueTrigger : MonoBehaviour
{
    public string playerTag = "Player";

    [Header("Optional")]
    public GameObject exclamationMark; // varsa

    [Header("Popup System")]
    public GameObject popupRoot; // boş bir parent (aktif/pasif için)
    public List<ChildPopupView> popups; // Zeynep, Demir, Yaşar sırasıyla

    [Header("Timing")]
    public float dialogueDuration = 5f;

    [Header("Quiz")]
    public QuizUI quizUI;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag(playerTag)) return;

        triggered = true;

        if (exclamationMark != null)
            exclamationMark.SetActive(false);

        popupRoot.SetActive(true);
        StartCoroutine(RunDialogue());
    }

    IEnumerator RunDialogue()
    {
        // hepsini kapat
        foreach (var p in popups)
            p.gameObject.SetActive(false);

        // sırayla aç
        foreach (var p in popups)
        {
            p.gameObject.SetActive(true);
            yield return new WaitForSeconds(dialogueDuration);
            p.gameObject.SetActive(false);
        }

        popupRoot.SetActive(false);

        if (quizUI != null)
            quizUI.StartQuiz();
    }
}
