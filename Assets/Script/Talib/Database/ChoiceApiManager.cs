using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ChoiceApiManager : MonoBehaviour
{
    public static ChoiceApiManager Instance;

    [SerializeField] private string apiUrl = "https://localhost:7192/api/Choices";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public IEnumerator SendChoice(ChoiceRequest request)
    {
        string json = JsonUtility.ToJson(request);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        UnityWebRequest webRequest = new UnityWebRequest(apiUrl, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Seçim başarıyla kaydedildi.");
            Debug.Log("Response: " + webRequest.downloadHandler.text);
        }
        else
        {
            Debug.LogError("API hatası: " + webRequest.error);
            Debug.LogError("Response: " + webRequest.downloadHandler.text);
        }
    }
}