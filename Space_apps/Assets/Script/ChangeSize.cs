using UnityEngine;
using System.Collections;

public class ChangeSize : MonoBehaviour
{

    public float scale = 10f;

    void Update()
    {
   
    }

    public void AdjustSize(float newScale)
    {
        scale = newScale;
        transform.localScale = new Vector3(scale, scale, scale);
    }

}