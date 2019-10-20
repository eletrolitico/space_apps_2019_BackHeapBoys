using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class BackButtonProgram : MonoBehaviour
{

    public void Back()
    {
        SceneManager.LoadScene("BeginMenu");
    }
}

