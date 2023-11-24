using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

public class TimeController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void JS_Alert(string str);


    public void GetMoscowTime()
    {
        StartCoroutine("GetMoscowTimeCoroutine");
    }

    public IEnumerator GetMoscowTimeCoroutine()
    {
        UnityWebRequest timeRequest = UnityWebRequest.Get("https://worldtimeapi.org/api/timezone/Europe/Moscow");
        yield return timeRequest.SendWebRequest();

        if (timeRequest.result != UnityWebRequest.Result.Success)
        {
            JS_Alert(timeRequest.error);
            //Debug.Log(timeRequest.error);
        }
        else
        {
            var json = timeRequest.downloadHandler.text;
            TimeResponse response = JsonUtility.FromJson<TimeResponse>(json);
            JS_Alert(response.datetime);
            //Debug.Log(timeRequest.error);
        }
    }

    [Serializable]
    public class TimeResponse
    {
        public string datetime;
    }
}
