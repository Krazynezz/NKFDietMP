using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class peritonial : MonoBehaviour
{
    Vector3 prev;
    RaycastHit hit;
    move fe;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("MainCamera"))
        {
            if (item.GetComponent<move>() != null)
                fe = item.GetComponent<move>();
        }
        prev = this.transform.position;
        fe.enabled = false;
    }

    // Update is called once. per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().position += new Vector3(Input.GetAxis("Horizontal") / 100, 0, 0);

    }
    private void FixedUpdate()

    {
        if (Physics.Raycast(this.transform.position, -Vector3.back, out hit))
        {
            if (hit.collider.tag == "water")
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                this.gameObject.GetComponent<Rigidbody>().position -= Vector3.down/10;
            }
        }
        if (Physics.Raycast(this.transform.position, -Vector3.back, out hit) == false)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "end")
        {
            fe.crosshair.active = true;
            fe.enabled = true;
            SceneManager.UnloadSceneAsync("Maze");
        }
    }
}
