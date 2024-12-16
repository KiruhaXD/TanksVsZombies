using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void Hello();

    //[DllImport("__Internal")]
    //private static extern void GetPlayerInformation();

    [DllImport("__Internal")]
    private static extern void GetRateFromPlayer();

    //[SerializeField] private RawImage imagePlayer;
    //[SerializeField] private TMP_Text namePlayer;

    //public void ButtonPlayer() => GetPlayerInformation();

    public void GetRate() => GetRateFromPlayer();

    /*public void SetName(string name) => namePlayer.text = name;

    public void SetPhoto(string url) => StartCoroutine(DownloadImage(url));

    IEnumerator DownloadImage(string mediaUrl) 
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            imagePlayer.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }*/
}
