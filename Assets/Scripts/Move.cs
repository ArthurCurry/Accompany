using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField]
    private int right;
    [SerializeField]
    private GameObject gapObj;
    private Gap gap;
    private float scoreTotal;
    private float scoreTemp;

	// Use this for initialization
	void Start () {
        gap = gapObj.GetComponent<Gap>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
	}

    void UpdatePosition()
    {
        Vector3 borderRight = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width,Screen.height/2,10));
        Vector3 borderLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10));
        if(right>0)
        {
            transform.position = (gapObj.transform.position + Vector3.right * gap.width/2 + borderRight) / 2;
        }
        else
        {
            transform.position = (gapObj.transform.position + Vector3.left * gap.width/2 + borderLeft) / 2;
        }
    }

   
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag.Equals("Thing"))
        {
            gap.UpdateTargetSize(true);
        }
        else if(collider.gameObject.tag.Equals(""))
        {
            gap.UpdateTargetSize(false);
        }
    }

    void UpdateLocalScore()
    {

    }

}
