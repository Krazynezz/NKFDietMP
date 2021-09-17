using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class peritonial : MonoBehaviour
{
    RaycastHit hit;
    move refer;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("MainCamera"))           //gets the camera in the main scene
        {
            if (item.GetComponent<move>())              //gets the script for the player movement
                refer = item.GetComponent<move>();              //and assigns it to be referenced later
        }
        refer.enabled = false;              //and disables it so the player cannot move in the main scene
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().position += new Vector3(Input.GetAxis("Horizontal") / 100, 0, 0);             //allows the player to only move the sphere horizontally
    }
    private void FixedUpdate()

    {
        if (Physics.Raycast(this.transform.position, -Vector3.back, out hit))               //shoots a ray from the sphere backwards
        {
            if (hit.collider.tag == "water")                    //if there is the water object behind the sphere
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;               //the sphere will stop being affected by gravity
                this.gameObject.GetComponent<Rigidbody>().position -= Vector3.down/10;          //and start moving upwards
            }
        }
        if (Physics.Raycast(this.transform.position, -Vector3.back, out hit) == false)          //if there is nothing behind the sphere since the water object is below the screen
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;            //the sphere will drop since there is gravity

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "end")          //when the sphere collides with the invisible end platform
        {
            refer.crosshair.SetActive(true);            //the crosshair from the main scene is back
            refer.enabled = true;                   //the player is allowed to move 
            refer.maze = true; ;                //one of the conditionsfor completing the game is cleared
            SceneManager.UnloadSceneAsync("Maze");          //and the maze puzzle scene is unloaded
        }
    }
}
