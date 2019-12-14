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
    private int[] thresholds = { -80,-60, -40, -20, 0, 20, 40 };    //阈值，每档中间不作响应
    private int x; //现在裂缝所在的挡位
    public float score_l;
    public float score_r;
	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider2D>();
        scaleSize_x = transform.localScale.x;
        targetScale_x = scaleSize_x;
        x = 4;
        score_l = 0;
        score_r = 0;
	}
	
	// Update is called once per frame
	void Update () {

        /*if(Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(transform.localScale.x);
            targetScale_x = scaleSize_x + diffPlus;
        }*/
        UpdateScore();
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

    public void UpdateScore()
    {
        float score_temp = (score_l + score_r) / 2;
        if (x == 0)
        {
            //游戏结束
        }
        else if (x == 6)
        {
            if(score_temp <=thresholds[x - 1])
            {
                UpdateTargetSize(true);
                x--;
            }
        }
        else
        {
            if (score_temp <= thresholds[x - 1])
            {
                UpdateTargetSize(true);
                x--;
            }
            if (score_temp >= thresholds[x + 1])
            {
                UpdateTargetSize(false);
                x++;
            }
        }
    }
}
