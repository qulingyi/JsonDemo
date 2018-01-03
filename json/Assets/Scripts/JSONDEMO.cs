using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONDEMO : MonoBehaviour {
     public GameObject myCam;
    //private int size;
    string path;
    string jsonString;
    // Use this for initialization
    void Start()
    {
        path = Application.streamingAssetsPath + "/json1.json"; //reads json file path
        jsonString = File.ReadAllText(path); //reads all the text of json
        propertyData data = JsonUtility.FromJson<propertyData>(jsonString);// declares and initializes a json structure object     
        camData cam = JsonUtility.FromJson<camData>(jsonString); // declares and initializes a json class object
        myCam.transform.position = new Vector3(cam.cameraPosition[0] * 0.01f, cam.cameraPosition[1] * 0.01f, cam.cameraPosition[2] * 0.01f);//change camera location according to json data
        //myCam.transform.Rotate(0, 90, 0);
        foreach (properties item in data.objects)//for every single model in the object list, do this
        {
            GameObject myObject = new GameObject();//initializes a new gameobject
            string path = item.model.obj;
            OBJ obj = myObject.AddComponent<OBJ>();
            StartCoroutine(obj.Load(path));
            myObject.transform.position = new Vector3(item.position[0], item.position[1], item.position[2]);  
            myObject.transform.localScale = new Vector3(item.w*0.02f, item.d * 0.02f, item.h * 0.02f);
            myObject.transform.Rotate(0, 0, 0);
            myObject.AddComponent<MeshFilter>();
            //myObject.AddComponent<BoundBox.cs>();
            //myObject.AddComponent<MeshCollider>();
            //myObject.AddComponent<MeshRenderer>();
            //Mesh mesh = myObject.GetComponent<MeshFilter>().mesh;
            //myObject.GetComponent<MeshCollider>().sharedMesh  = mesh;
            //MeshCollider meric = GetComponent<MeshCollider>();
            //Bounds bounds = myObject.GetComponent<MeshFilter>().mesh.bounds;
            Vector3 x = myObject.GetComponent<MeshFilter>().mesh.bounds.size;
            Debug.Log(x);
            
        }
    }

    // Update is called once per frame
    [System.Serializable]
    public class camData 
    {
        public float[] cameraPosition;
    } //camera data class
    [System.Serializable]
    public class propertyData
    {
        public List<properties> objects;
    } //
    [System.Serializable]
    public struct properties 
    {
        public float[] position;
        public float rotate;
        public float w;
        public float d;
        public float h;
        public modelProperty model;
    }  //structure inside the objects list
    [System.Serializable]
    public struct modelProperty
    {
        public string name;
        public string obj;
    }
    
}
