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
    public GameObject spawning2;
    public GameObject spawningpipe;
    float spawned = 1;
    move refer;
    public float pipetrue;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        spawn = spawningpipe.transform.position;
        foreach (var item in GameObject.FindGameObjectsWithTag("MainCamera"))
        {
            if (item.GetComponent<move>())
                refer = item.GetComponent<move>();
        }
        refer.enabled = false;
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
        // if (Input.GetButtonDown("Fire2"))
        if (pipetrue == 2)
        {
            SceneManager.UnloadScene("Pipes");
            Cursor.lockState = CursorLockMode.Locked;
            refer.enabled = true;
            refer.pipes = true;
        }
        elaspe += Time.deltaTime;
         if (Mathf.Ceil(elaspe) % 5 ==0 && Mathf.Ceil(elaspe) / 10 == spawned)
         {
            if (Random.value >= 0.5f)
            {
                Instantiate(spawning, spawn, Quaternion.identity);
                spawned += 1;
            }
            else
            {
                Instantiate(spawning2, spawn, Quaternion.identity);
                spawned += 1;
            }
        }
    }
}
