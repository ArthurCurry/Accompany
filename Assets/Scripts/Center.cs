using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour {

    private bool isA; //与Thing里面的共同判断能被该中心点吸收

	// Use this for initialization
	void Start () {
        isA = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider .tag == "Thing")
        {
            if(this .isA && collider .GetComponent <Test >().isA)
            {
                collider.GetComponent<Test>().Accept();
            }
        }
    }
}
