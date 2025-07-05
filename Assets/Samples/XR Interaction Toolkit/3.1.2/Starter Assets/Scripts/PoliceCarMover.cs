using UnityEngine;

public class PoliceCarMover : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float stopDistance = 0.1f;
    public Transform[] wheels;
    public float wheelRotationSpeed = 360f;

    private bool isMoving = false;

    void Start()
    {
        // Araba sahneye geldiði gibi harekete baþlasýn
        StartMoving();
    }
    void Update()
    {
        

        if (isMoving && Vector3.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target);

            // Tekerlekleri döndür
            foreach (Transform wheel in wheels)
            {
                wheel.Rotate(Vector3.right * wheelRotationSpeed * Time.deltaTime);
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        GetComponent<AudioSource>().Play();
    }

}
