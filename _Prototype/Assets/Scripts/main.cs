using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public void nextscene()
    {
        SceneManager.LoadScene("Cafeteria", LoadSceneMode.Single);              //when start is clicked this funtion should be called by the button to enter the main scene
    }
}
