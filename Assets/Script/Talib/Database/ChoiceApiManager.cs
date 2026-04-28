using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ChoiceApiManager : MonoBehaviour
{
    public static ChoiceApiManager Instance;
    [SerializeField] private string apiUrl = "http://10.10.21.192:5136/api/Choices";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SendChoice(ChoiceRequest request, Action<bool> onResult)
    {
        Debug.Log("SEND CHOICE CALLED");
        Debug.Log("API URL: " + apiUrl);

        if (request != null)
        {
            Debug.Log("Request object is NOT null");
        }
        else
        {
            Debug.LogError("Request object is NULL");
        }

        StartCoroutine(SendChoiceCoroutine(request, onResult));
    }
    private IEnumerator SendChoiceCoroutine(ChoiceRequest request, Action<bool> onResult)
    {
        Debug.Log("API REQUEST START");

        string json = JsonUtility.ToJson(request);
         Debug.Log("JSON SENT: " + json);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        UnityWebRequest webRequest = new UnityWebRequest(apiUrl, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.timeout = 10;

        yield return webRequest.SendWebRequest();

        Debug.Log("REQUEST FINISHED");
        Debug.Log("RESULT: " + webRequest.result);
        Debug.Log("RESPONSE CODE: " + webRequest.responseCode);
        Debug.Log("RESPONSE TEXT: " + webRequest.downloadHandler.text);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Success: " + webRequest.downloadHandler.text);
            onResult?.Invoke(true); // Tell the UI it worked!
        }
        else
        {
            Debug.LogError("API Error: " + webRequest.error);
            onResult?.Invoke(false); // Tell the UI it failed
        }
    }
}