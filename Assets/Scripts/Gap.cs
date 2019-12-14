using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gap : MonoBehaviour {

    private BoxCollider2D collider;
    private float scaleSize_x;
    private float targetScale_x;
    [SerializeField]
    private float diff;
    [SerializeField]
    private float growSpeed;
    [HideInInspector]
    public float width;//宽
    [HideInInspector]
    public float height;
    private int[] thresholds = { -80, -40, -20, 0, 20, 40 };    //阈值，每档中间不作响应
	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider2D>();
        scaleSize_x = transform.localScale.x;
        targetScale_x = scaleSize_x;
	}
	
	// Update is called once per frame
	void Update () {
        
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(transform.localScale.x);
            targetScale_x = scaleSize_x + diffPlus;
        }*/
        GapGrow();
	}

    public void GapGrow()
    {
        if(targetScale_x!=scaleSize_x)
        {
            scaleSize_x = Mathf.Lerp(scaleSize_x, targetScale_x, Time.timeScale * growSpeed);
            transform.localScale = new Vector3(scaleSize_x, transform.localScale.y, transform.localScale.z);
        }
        if(Mathf.Abs(targetScale_x-transform.localScale.x)<(diff/50)&& Mathf.Abs(targetScale_x - transform.localScale.x)>0f)
        {
            transform.localScale = new Vector3(targetScale_x, transform.localScale.y, transform.localScale.z);
        }
        width = transform.localScale.x * collider.size.x;
    }

    public void UpdateTargetSize(bool larger)
    {
        if (larger)
        {
            targetScale_x = scaleSize_x + diff;
        }
        else
        {
            targetScale_x = scaleSize_x - diff;
        }
    }

    public void UpdateDiff(float targetDiff)
    {
        diff = targetDiff;
    }
}
