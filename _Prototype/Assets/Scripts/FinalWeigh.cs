using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FinalWeigh : MonoBehaviour
{
    float num = 0;
    public GameObject connectdoor;
    public GameObject connectdoor2;
    public GameObject[] root;
    public GameObject player;
    static bool[] weighs = new bool[] { false,false,false };
    static int weighindex = 0;
    static int complete = 0;
    public Vector3 weighplate;
    Vector3 off;

    GameObject[] fruitObjects;
    GameObject[] weighObjects;
    private GameObject A1;
    private GameObject A2;
    private GameObject S1;
    private GameObject S2;
    private GameObject B1;
    private GameObject B2;

    private GameObject A3;
    private GameObject A4;
    private GameObject A5;
    private GameObject G1;
    private GameObject G2;
    private GameObject G3;
    private GameObject G4;
    private GameObject G5;
    private GameObject BA1;
    private GameObject BA2;
    private GameObject STB1;
    private GameObject BLB1;
    private GameObject L1;
    private GameObject L2;



    // Start is called before the first frame update
    void Start()
    {
        off = new Vector3(0.4f, 0, 0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 2)
        {
            weighs[weighindex] = true;
            weighindex++;
            num++;
        }
        foreach (var item in weighs)
            {
            if (item == true)
            {   
                complete++;
                
            }
            if (item == false)
            {
                complete = 0;
            }
            }
        if (complete ==3)
        {
            FindFruits();
            DestroyAllFinalWeighObjects();
            Destroy(this.gameObject);
            connectdoor.GetComponent<Animator>().SetBool("character_nearby", true);
            connectdoor2.GetComponent<Animator>().SetBool("character_nearby", true);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "interactable" )
        {
            player.GetComponent<move>().interacted = false;
            other.transform.position = weighplate + off *(num-1);
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        foreach (var item in root)
        {
            if (other.gameObject == item)
            {
                num++;
            }

        }
   
    }

    void DestroyAllFinalWeighObjects()
    {
        fruitObjects = GameObject.FindGameObjectsWithTag("FWFruit");

        for (var i = 0; i < fruitObjects.Length; i++)
        {
            Destroy(fruitObjects[i]);
        }

        weighObjects = GameObject.FindGameObjectsWithTag("FinalWeigh");

        for (var i = 0; i < weighObjects.Length; i++)
        {
            Destroy(weighObjects[i]);
        }
    }

    void FindFruits()
    {
        A1 = GameObject.Find("FinalApple1");
        A2 = GameObject.Find("FinalApple2");
        S1 = GameObject.Find("FinalStrawberry1");
        S2 = GameObject.Find("FinalStrawberry2");
        B1 = GameObject.Find("FinalBlueberry2");
        B2 = GameObject.Find("FinalBlueberry2");

        A3 = GameObject.Find("Apple3");
        A4 = GameObject.Find("Apple4");
        A5 = GameObject.Find("Apple5");
        G1 = GameObject.Find("Grape1");
        G2 = GameObject.Find("Grape2");
        G3 = GameObject.Find("Grape3");
        G4 = GameObject.Find("Grape4");
        G5 = GameObject.Find("Grape5");
        BA1 = GameObject.Find("Banana1");
        BA2 = GameObject.Find("Banana2");
        STB1 = GameObject.Find("Strawberry1");
        BLB1 = GameObject.Find("Blueberry1");
        L1 = GameObject.Find("Lemon1");
        L2 = GameObject.Find("Lemon2");
        Destroy(A1);
        Destroy(A2);
        Destroy(S1);
        Destroy(S2);
        Destroy(B1);
        Destroy(B2);

        Destroy(A3);
        Destroy(A4);
        Destroy(A5);
        Destroy(G1);
        Destroy(G2);
        Destroy(G3);
        Destroy(G4);
        Destroy(G5);
        Destroy(BA1);
        Destroy(BA2);
        Destroy(STB1);
        Destroy(BLB1);
        Destroy(L1);
        Destroy(L2);
    }
}
