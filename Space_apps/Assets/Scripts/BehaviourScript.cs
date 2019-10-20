using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour
{
    public int mass, temp, radio;


    // expand -> increasing with our radio (this is our size)
    public void increaseSize()
    {
        transform.localScale = 2 * radio * transform.localScale;  
    }

    public void increaseTemp()
    {
        // need change img
    }

    public void increaseMass()
    {

    }


}
