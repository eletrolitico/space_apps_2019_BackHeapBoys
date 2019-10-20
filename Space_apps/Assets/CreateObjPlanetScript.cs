using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System;

public class CreateObjScriptPlanet : MonoBehaviour
{

    public GameObject go;

    public InputField massField;
    public InputField tempField;
    public InputField radioField;

    public Text text;

    int numPlanets = 0;

    private string smass, stemp, sradio;
    private int mass, temp, radio;


    private bool flag = false;

    public void onClick()
    {
      
        smass = massField.text;
        stemp = tempField.text;
        sradio = radioField.text;

        mass = int.Parse(smass);
        temp = int.Parse(stemp);
        radio = int.Parse(sradio);

        text.text = "oi, vai funcionar. Eu acredito em você, você nasceu para brilhar, muito obrigado->" + smass;

        Instantiate(go, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));



     
    }






}
