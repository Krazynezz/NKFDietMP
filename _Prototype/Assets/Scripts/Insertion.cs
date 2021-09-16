using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject")]
    public class Insertion : ScriptableObject
{
        public GameObject[] interactables;      //an list of gameobjects then is saved so that they can be used as reference later
}
