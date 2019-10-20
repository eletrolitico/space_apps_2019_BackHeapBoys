using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Program");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene("PanoramicScene");
    }

  
}
