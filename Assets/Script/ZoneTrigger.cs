using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public string playerTag = "Player";

    [Header("Popup")]
    public GameObject childPopupPrefab;
    public Vector3 popupOffset = new Vector3(0, 0.25f, 0);

    [System.Serializable]
    public class ChildData
    {
        public Transform popupAnchor;
        public Sprite popupSprite; // yazısı PNG'nin içinde
    }

    public List<ChildData> children = new List<ChildData>();

    [System.Serializable]
    public class DialogueStep
    {
        public int childIndex;
        public float duration = 2f;
    }

    public List<DialogueStep> dialogueOrder = new List<DialogueStep>();

    [Header("Quiz")]
    public QuizUI quizUI;

    private List<ChildPopupView> views = new List<ChildPopupView>();
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER: " + other.name + " tag=" + other.tag);
        if (triggered) return;
        if (!other.CompareTag(playerTag)) return;

        triggered = true;
        StartCoroutine(RunDialogue());
    }

    IEnumerator RunDialogue()
    {
        SpawnPopups();

        // Hepsini kapat
        foreach (var v in views)
            v.SetVisible(false);

        // Sırayla göster
        foreach (var step in dialogueOrder)
        {
            if (step.childIndex < 0 || step.childIndex >= views.Count)
                continue;

            // Sadece ilgili çocuk açık
            for (int i = 0; i < views.Count; i++)
                views[i].SetVisible(i == step.childIndex);

            yield return new WaitForSeconds(step.duration);
        }

        // Konuşma bitti → kapat
        foreach (var v in views)
            v.SetVisible(false);

        // Quiz başlat
        if (quizUI != null)
            quizUI.StartQuiz();
    }

    void SpawnPopups()
    {
        views.Clear();

        foreach (var c in children)
        {
            var go = Instantiate(childPopupPrefab, c.popupAnchor);
            go.transform.localPosition = popupOffset;

            var view = go.GetComponent<ChildPopupView>();
            view.Set(c.popupSprite);

            views.Add(view);
        }
    }
}
