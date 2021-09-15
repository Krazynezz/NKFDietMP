using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
    {
    Vector3 origin;
    Quaternion originrot;
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
    string[] rightans = new string[4] { "2","1","7","3"};
    public GameObject[] keylights = new GameObject[4];
    float answered;
    public GameObject crosshair;
    public GameObject crosshand;
    public bool maze;
    public bool pipes;
    public GameObject teleporter;
    public GameObject[] mazeshader = new GameObject[2];
    public GameObject[] pipeshader = new GameObject[2];
    public Material greenshader;
    // Start is called before the first frame update
    void Start()
        {
        Cursor.lockState = CursorLockMode.Locked;
        }

    // Update is called once per frame
    private void FixedUpdate()
    {

           front = transform.forward * Input.GetAxis("Vertical");
        left = transform.right * Input.GetAxis("Horizontal");
        movement = front + left;
        movement.y = 0;
        player.Move(movement / 20);
        player.transform.position = new Vector3(transform.position.x,-1.1f,transform.position.z);

    }



    void Update()
    {
        if (maze == true)
        {
            foreach (var item in mazeshader)
            {
                item.GetComponent<Renderer>().material = greenshader;
            }
        }
        if (pipes == true)
        {
            foreach (var item in pipeshader)
            {
                item.GetComponent<Renderer>().material = greenshader;
            }
        }
        if(maze == true && pipes == true)
        {
            teleporter.SetActive(true);
        }

        transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0);


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out objects, 1))
            {
            if (objects.collider.tag == "interactable")
            {
                crosshair.SetActive(false);
                crosshand.SetActive(true);
            }
            if (Input.GetButtonDown("Fire1") && interacted == false)
            {
                if (objects.collider.gameObject.GetComponent<AudioSource>() != null)
                {
                    this.gameObject.GetComponent<AudioSource>().clip = objects.collider.gameObject.GetComponent<AudioSource>().clip;
                    this.gameObject.GetComponent<AudioSource>().Play();
                    objects.collider.gameObject.GetComponent<AudioSource>().clip = null;
                }
                if (objects.collider.tag == "interactable")
                {
                    origin =  objects.collider.gameObject.GetComponent<origin>().originpos;
                    originrot = objects.transform.rotation;
                    interacting = objects.collider.gameObject;
                    interacted = true;
                }
                if (objects.collider.tag == "hemo" && !SceneManager.GetSceneByName("Pipes").isLoaded)
                {
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("Pipes", LoadSceneMode.Additive);
                    crosshair.SetActive(false);


                }
                if (objects.collider.tag == "peritonial" && !SceneManager.GetSceneByName("Maze").isLoaded)
                {
                    SceneManager.LoadScene("Maze", LoadSceneMode.Additive);
                    crosshair.SetActive(false);

                }
                if (objects.collider.tag == "button")
                {
                    input[order] = objects.collider.name;
                    keylights[order].GetComponent<MeshRenderer>().material.color = Color.green;
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
                            foreach (var item in keylights)
                            {
                                item.GetComponent<MeshRenderer>().material.color = Color.red;
                            }
                            order = 0;
                            answered = 0;
                        }
                    }
                }
            }
            }
       else
        {
            crosshair.SetActive(true);
            crosshand.SetActive(false);
        }
            if (Input.GetButtonDown("Fire2") && interacted != false)
            {
                interacting.transform.position = origin;
                interacting.transform.rotation = originrot;
                interacting = null;
                interacted = false;
            }

        if (interacted)
            {
                interacting.transform.position = this.transform.position + transform.forward - transform.up/10;
                interacting.transform.rotation = this.transform.rotation * Quaternion.Euler(-10,0,0);
            }
        }
    }
