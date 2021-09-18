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
        Cursor.lockState = CursorLockMode.Locked;           //the mouse position is locked to the middle of the screen
        }

    // Update is called once per frame
    private void FixedUpdate()
    {
        front = transform.forward * Input.GetAxis("Vertical");          //gets the vertical inputs of the user
        left = transform.right * Input.GetAxis("Horizontal");           //gets the horizontal inputs of the user
        movement = front + left;                        //adds the two inputs together
        player.Move(movement / 20);             //moves the player according to their input at a lower rate
        player.transform.position = new Vector3(transform.position.x,-1.1f,transform.position.z);           //resets the height of the player if he tries to climb an object

    }



    void Update()
    {
        if (maze == true)           //if the maze has been cleared
        {
            foreach (var item in mazeshader)        //the two components of the patient hologram
            {
                item.GetComponent<Renderer>().material = greenshader;           //will turn green
            }
        }
        if (pipes == true)          //if the pipes has been cleared
        {
            foreach (var item in pipeshader)               //the two components of the patient hologram
            {
                item.GetComponent<Renderer>().material = greenshader;      //will turn green
            }
        }
        if(maze == true && pipes == true)           //if both conditions have been cleared
        {
            teleporter.SetActive(true);         //the teleporter will appear
        }

        transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0);           //changes the rotation of the camera based on mouse movement input


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                //shoots a ray from the middle of the screen since the mouse is locked
            if (Physics.Raycast(ray, out objects, 1))           //of distance 1
            {
            if (objects.collider.tag == "interactable")             //if it hits an interactable object
            {
                crosshair.SetActive(false);         //disables the crosshair 
                crosshand.SetActive(true);          //and displays a hand
            }
            if (Input.GetButtonDown("Fire1") && interacted == false)            //if the player clicks and is not already holding an object
            {
                if (objects.collider.gameObject.GetComponent<AudioSource>() != null)            //if the object has audio source component attached and audio clip
                {
                    this.gameObject.GetComponent<AudioSource>().clip = objects.collider.gameObject.GetComponent<AudioSource>().clip;            //the player audio source will play its clip
                    this.gameObject.GetComponent<AudioSource>().Play();
                    objects.collider.gameObject.GetComponent<AudioSource>().clip = null;            //and the object will no longer have a clip attached
                }
                if (objects.collider.tag == "interactable")         //if the object is interactable
                {
                    origin =  objects.collider.gameObject.GetComponent<origin>().originpos;     //the player saves its original position from its origin script
                    originrot = objects.transform.rotation;         //and original rotation
                    interacting = objects.collider.gameObject;          //and declares that what object it is holding
                    interacted = true;              //and that it is holding an object
                }
                if (objects.collider.tag == "hemo" && !SceneManager.GetSceneByName("Pipes").isLoaded)           //if the player clicks on the hemodialysis machine
                {
                    Cursor.lockState = CursorLockMode.None;         //the mouse is unlocked
                    SceneManager.LoadScene("Pipes", LoadSceneMode.Additive);            //and the pipe scene is loaded
                    crosshair.SetActive(false);         //and the crosshair disappears


                }
                if (objects.collider.tag == "peritonial" && !SceneManager.GetSceneByName("Maze").isLoaded)              //if the player clicks on the peritonial dialysis machine
                {
                    SceneManager.LoadScene("Maze", LoadSceneMode.Additive);         //the maze scene is loaded
                    crosshair.SetActive(false);             //and the crosshair disappears

                }
                if (objects.collider.tag == "button")               //if the player clicks on keypad buttons
                {
                    input[order] = objects.collider.name;           //the array will store the number pressed
                    keylights[order].GetComponent<MeshRenderer>().material.color = Color.green;         //and the corresponding indicator will turn green
                    order += 1;             //and go to the next number to be pressed
                    if (order == 4)             //if the player has clicked all numbers
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (input[i] == rightans[i])            //if each number in the position matches with the right answer
                            {
                                answered += 1;          //the number of correct answer the play has entered incrceases by one
                            }
                        }
                        if (answered == 4)          //if all four answers are correct
                        {
                            Instantiate(redcan, container.transform.position, Quaternion.Euler(0,90,0));        //then the drinks prefab is spawned
                        }
                        if (answered < 4)           //if there is at least one wrong answer
                        {
                            foreach (var item in keylights)         //gets all the indcators
                            {
                                item.GetComponent<MeshRenderer>().material.color = Color.red;           //all of the indicators will turn red
                            }
                            order = 0;          //and the input will go back to the first position to wait for next round of input
                            answered = 0;           //and the number of inputs will reset
                        }
                    }
                }
            }
            }
       else
        {
            crosshair.SetActive(true);          //if the ray does not hit an interacterble object then the crosshair will appear
            crosshand.SetActive(false);         //and the hand will disappear
        }
            if (Input.GetButtonDown("Fire2") && interacted != false)        //if the player right clicks
            {
                interacting.transform.position = origin;            //the object will move back to its original position
                interacting.transform.rotation = originrot;         //and rotation
                interacting = null;             //and declare that no object is being held
                interacted = false;             //and declare that it is no longer holding an object
        }

        if (interacted)            //if the player is holding an object 
        {
                interacting.transform.position = this.transform.position + transform.forward - transform.up/10;         //the object will move based on the player position and be in front of the player
                interacting.transform.rotation = this.transform.rotation * Quaternion.Euler(-10,0,0);               //and its rotation will also follow so that it always faces the player
            }
        }
    }
