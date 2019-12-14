using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour {

    public bool isLeft; //与Thing里面的共同判断能被该中心点吸收

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) //吸收东西
    {
        if(collider .tag == IDRegister .thingTag)
        {
            if(this .isLeft && collider .GetComponent <Test >().isLeft || !this.isLeft && !collider.GetComponent<Test>().isLeft)
            {
                collider.GetComponent<Thing>().Accept();
            }
        }
    }
}
