using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class URL : MonoBehaviour {
    public GameObject s;
    
  
   
    // Use this for initialization
    void Start ()
    {
        //string id = Request.QueryString["id"];
        // int p = Application.absoluteURL.IndexOf("?");
        //if (p != -1)
        // {
        string q = Application.absoluteURL;
        //string q = "size=7";
            //int t = q.Length - 1;
        string[] stringSeparators = new string[] { "size=" };
        //string m = q.Split("size="[0])[1];
        string[] m = q.Split(stringSeparators, StringSplitOptions.None);
        int si = int.Parse(m[1]);
        //s.GetComponent<TextMesh>().text = t.ToString();
            //int si = int.Parse(PreviewLabs.RequestParameters.GetValue(size));
           s.transform.localScale += new Vector3(si, si, si);
            Debug.Log(m);
       // }
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
 

}
