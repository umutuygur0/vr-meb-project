using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;
    public string UserId { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            UserId = PlayerPrefs.HasKey("userId")
                ? PlayerPrefs.GetString("userId")
                : CreateNewUserId();
        }
        else Destroy(gameObject);
    }

    private string CreateNewUserId()
    {
        string id = System.Guid.NewGuid().ToString();
        PlayerPrefs.SetString("userId", id);
        return id;
    }
}