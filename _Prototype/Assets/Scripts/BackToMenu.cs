using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void LoadBackToMenu()
    {
        SceneManager.LoadScene("Start_Screen"); // Upon pressing the back button, it will load the Start Screen scene
    }
}
