using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits"); // This will load the credit screen
    }
}
