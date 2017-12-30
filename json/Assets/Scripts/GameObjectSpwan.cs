using UnityEngine;
using System.Collections;

public class GameObjectSpawn : MonoBehaviour
{
    //store gameObject reference
    GameObject objToSpawn;

    void Start()
    {
        //spawn object
        objToSpawn = new GameObject("cool");
        //Add Components
        objToSpawn.AddComponent<Rigidbody>();
        objToSpawn.AddComponent<MeshFilter>();
        objToSpawn.AddComponent<BoxCollider>();
        objToSpawn.AddComponent<MeshRenderer>();
    }
}
