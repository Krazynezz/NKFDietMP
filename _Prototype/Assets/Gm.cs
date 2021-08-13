using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gm : MonoBehaviour
{
    GameObject current;
    public Camera camera;
    float elaspe;
     Vector3 spawn;
    public GameObject spawning;
    float spawned = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        spawn = new Vector3(18.5f, 11.8f, 8.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                if (hit.collider.tag == "pipe")
                {
                    current = hit.collider.gameObject;
                    current.transform.RotateAround(hit.collider.bounds.center, Vector3.forward, 90);
                }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.UnloadScene("Pipes");
            Cursor.lockState = CursorLockMode.Locked;            
        }
        elaspe += Time.deltaTime;
         if (Mathf.Ceil(elaspe) % 5 ==0 && Mathf.Ceil(elaspe) / 5 == spawned)
         {
            Instantiate(spawning, spawn, Quaternion.identity);
            spawned += 1;
         }
    }
}
