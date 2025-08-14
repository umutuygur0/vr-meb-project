using UnityEngine;
using UnityEngine.UI; // Normal UI Text

public class PoliceWalker : MonoBehaviour
{
    public float walkSpeed = 2f;
    private Transform target;
    private Animator animator;

    [Header("Mesaj Ayarları")]
    public CanvasGroup messageCanvasGroup; // CanvasGroup ile fade kontrolü
    public Text messageText;               // Normal UI Text
    public float fadeDuration = 1.5f;      // Ne kadar sürede görünsün
    private bool messageShown = false;

    public void SetTarget(Transform walkTarget)
    {
        target = walkTarget;
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        // Mesaj başta görünmesin
        if (messageCanvasGroup != null)
            messageCanvasGroup.alpha = 0;
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, walkSpeed * Time.deltaTime);
            transform.LookAt(target);

            if (animator != null)
                animator.SetBool("isWalking", true);
        }
        else
        {
            if (animator != null)
                animator.SetBool("isWalking", false);

            if (!messageShown)
            {
                messageShown = true;
                ShowMessage("ZORBA OLMA, KANKA OL");
            }
        }
    }

    void ShowMessage(string text)
    {
        if (messageText != null)
            messageText.text = text;

        if (messageCanvasGroup != null)
            StartCoroutine(FadeIn());
    }

    System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            messageCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }
    }
}
