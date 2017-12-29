﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONDEMO : MonoBehaviour {
   public GameObject myObject;
    //private int size;
    string path;
    string jsonString;
    // Use this for initialization
    void Start()
    {
        path = Application.streamingAssetsPath + "/json1.json";
        jsonString = File.ReadAllText(path);
        //Scaling sphere = JsonUtility.FromJson<Scaling>(jsonString);
        //Debug.Log(sphere.size);
        //myObject.transform.localScale += new Vector3(0, 0, 0);
        //Models myModel = JsonUtility.FromJson<Models>(jsonString);
        propertyData data = JsonUtility.FromJson<propertyData>(jsonString);
         
        //foreach (properties item in data.objects)
        //{
        //    Debug.Log(item.h);
        //}
        foreach (properties item in data.objects)
        {
            string path = item.model.obj;
            OBJ obj = myObject.AddComponent<OBJ>();
            StartCoroutine(obj.Load(path));
            Debug.Log(item.model.name);
        }
    }

    // Update is called once per frame
    [System.Serializable]
    public struct properties
    {
        public Vector3 position;
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
