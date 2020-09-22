using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class MonthTeller : MonoBehaviour
{
    public GameObject timeTextObject;

    // Start is called before the first frame update
    void Start()
    {
    InvokeRepeating("UpdateTime", 0f, 10f);
    }

    // Update is called once per frame
    void UpdateTime()
    {
      var curMonth = System.DateTime.Now;


      timeTextObject.GetComponent<TextMeshPro>().text = curMonth.ToString("MMM");

    }
}
