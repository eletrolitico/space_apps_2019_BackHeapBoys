using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject menu;
    private Animation anim;
    bool act = false;

    void OnEnable()
    {
   
        anim = menu.GetComponent<Animation>();
    }

    void TongueOut()
    {
        anim.Play("TongueOut");
    }
    void TongueIn()
    {
        anim.Play("TongueIn");
    }

    public void onClick()
    {  
        if (act)
        {
            TongueOut();
        }
        else
        {
            TongueIn();
        }
        act = !act;
    }
}
