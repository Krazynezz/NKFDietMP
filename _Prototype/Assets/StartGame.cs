using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadNewGame()
    {
        SceneManager.LoadScene("Cafeteria"); // This will load the main gameplay screen
    }
}
