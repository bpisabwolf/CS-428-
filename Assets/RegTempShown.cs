using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;

public class RegTempShown : MonoBehaviour
{
  public GameObject weatherTextObject;
  public NumberFormatInfo formatProvider = new NumberFormatInfo();
    string curTemp;
    double numTemp;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curTemp = weatherTextObject.GetComponent<TextMeshPro>().text;
        if(!curTemp.Equals("0 F")){
          numTemp = Convert.ToDouble(curTemp, formatProvider);
          Debug.Log("\nCurrent temp is: " + numTemp);
        }

    }
}
