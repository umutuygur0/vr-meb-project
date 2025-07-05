using UnityEngine;

public class PoliceWalker : MonoBehaviour
{
    public float walkSpeed = 2f;
    private Transform target;
    private Animator animator;

    public void SetTarget(Transform walkTarget)
    {
        target = walkTarget;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
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
        }
    }
}
