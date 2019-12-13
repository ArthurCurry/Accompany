using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Thing[] things;

    public Transform pos;


	// Use this for initialization
	void Start () {   
		if(things.Length > 0)
        {            
            things[0].Init(1, 1000, 1, true, pos);
            //things[0].Fly(p);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
