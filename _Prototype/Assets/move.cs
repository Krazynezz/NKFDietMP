using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
    {
        public CharacterController player;
        public Transform rotation;
    public GameObject redcan;
    public GameObject container;
    RaycastHit objects;
        GameObject interacting;
        public bool interacted = false;
        Vector3 movement;
        Vector3 front;
        Vector3 left;
        string [] input = new string[4];
        int order;
    string[] rightans = new string[4] { "1","2","3","4"};
    float answered;
    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
        front = transform.forward * Input.GetAxis("Vertical");
        left = transform.right * Input.GetAxis("Horizontal");
        movement = front + left;
        movement.y = 0;
        player.Move(movement / 50);
        transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X") , 0);





        if (Input.GetButtonDown("Fire1"))
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out objects, 1))
            {
                if (objects.collider.tag == "interactable")
                {
                    interacting = objects.collider.gameObject;
                    interacted = true;
                }
                if (objects.collider.tag == "hemo" && !SceneManager.GetSceneByName("Pipes").isLoaded)
                {
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("Pipes", LoadSceneMode.Additive);
                    crosshair.active = false;


                }
                if (objects.collider.tag == "peritonial" && !SceneManager.GetSceneByName("Maze").isLoaded)
                {
                    SceneManager.LoadScene("Maze", LoadSceneMode.Additive);
                    crosshair.active = false;

                }
                if (objects.collider.tag == "button")
                {
                    input[order] = objects.collider.name;
                    order += 1;
                    Debug.Log(input[order - 1]);
                    if (order == 4)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (input[i] == rightans[i])
                            {
                                answered += 1;
                            }
                        }
                        if (answered == 4)
                        {
                            Instantiate(redcan, container.transform.position, Quaternion.Euler(0,90,0));
                        }
                        if (answered < 4)
                        {
                            order = 0;
                            answered = 0;
                        }
                    }
                }
            }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                interacting = null;
                interacted = false;
            }
                if (interacted)
            {
                interacting.transform.position = this.transform.position + transform.forward;
                interacting.transform.rotation = this.transform.rotation;
            }
        }
    }
