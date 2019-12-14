using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ss : MonoBehaviour {

    public float speed;
    public Transform target;
    public Vector3 a;
    public float height;

	// Use this for initialization
	void Start () {
        height = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y * gameObject.transform.localScale.y;
        Debug.Log(height);
        a = new Vector3(0, -8.0f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(a, Vector3.forward, 50 * Time.deltaTime);
	}
}
