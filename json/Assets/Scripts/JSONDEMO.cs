using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONDEMO : MonoBehaviour {
     public GameObject myCam;
    //private int size;
    string path;
    string jsonString;
    public properties cam;
    // Use this for initialization
    void Start()
    {
        path = Application.streamingAssetsPath + "/json1.json"; //Get json file
        jsonString = File.ReadAllText(path); //Get all the text of json
        propertyData data = JsonUtility.FromJson<propertyData>(jsonString);//parse the json text 
       
        myCam.transform.position = new Vector3(cam.cameraPosition[0], cam.cameraPosition[1], cam.cameraPosition[2]);
        foreach (properties item in data.objects)//for every single model do this
        {
            GameObject myObject = new GameObject();
            string path = item.model.obj;
            OBJ obj = myObject.AddComponent<OBJ>();
            StartCoroutine(obj.Load(path));
            myObject.transform.position = new Vector3(item.position[0], item.position[1], item.position[2]);
            myObject.transform.localScale = new Vector3(item.w, item.d, item.h);
        }
        //Debug.Log(item.position[0]);
       
    }

    // Update is called once per frame
    [System.Serializable]
    public struct properties
    {
        public float[] cameraPosition;
        public float[] position;
        public float rotate;
        public float w;
        public float d;
        public float h;
        public modelProperty model;
    }
    [System.Serializable]
    public struct modelProperty
    {
        public string name;
        public string obj;
    }
    [System.Serializable]
    public class propertyData
    {
        public List<properties> objects;
    }
}
