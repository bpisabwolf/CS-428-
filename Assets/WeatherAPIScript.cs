using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class WeatherAPIScript : MonoBehaviour
{
    string finalWeather;
    string rawWeather;
    public GameObject weatherTextObject;
       string url = "http://api.openweathermap.org/data/2.5/weather?lat=41.88&lon=-87.6&APPID=516180e91be9a7f03c0537d55c9d5d7f&units=imperial";


    void Start()
    {

    // wait a couple seconds to start and then refresh every 900 seconds

       InvokeRepeating("GetDataFromWeb", 2f, 900f);
   }

   void GetDataFromWeb()
   {

       StartCoroutine(GetRequest(url));
   }

   string GetWeatherFromData(string raw){
     int findLength = "\"temp\":".Length;
     int indEnd = raw.IndexOf("\"temp\":") + findLength;
     int after = raw.IndexOf(",\"feels_like\":");
     Debug.Log("Index indEnd and after is: " + indEnd + ", " + after);
     string temp = raw.Substring(indEnd, after - indEnd);
     return temp;
    }

    IEnumerator GetRequest(string uri)
    {
      Debug.Log("Raw uri: " + uri);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                rawWeather = webRequest.downloadHandler.text;
                finalWeather = GetWeatherFromData(rawWeather);
                weatherTextObject.GetComponent<TextMeshPro>().text = finalWeather + "F";
            }
        }
    }
}
