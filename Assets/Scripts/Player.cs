using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed; //移动速度

    public Transform pos;

	// Use this for initialization
	void Start () {
        speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        if(Input .GetKey (KeyCode.W))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        else if(Input .GetKey(KeyCode.S))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        else if(Input .GetKey (KeyCode.A))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        else if(Input .GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider .tag == "Thing")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Vector2 a = (pos.position - collider.transform.position).normalized;
                collider.GetComponent<Test>().Fly(a);
            }
        }
    }
}
