using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour {

    [SerializeField]
    private int right;
    [SerializeField]
    private GameObject gapObj;
    private Gap gap;
    private float scoreTotal;
    private float scoreTemp;

    private GameObject eat_s;
    public GameObject eat_w;

	// Use this for initialization
	void Start () {
        gap = gapObj.GetComponent<Gap>();
        eat_s = Resources.Load<GameObject>("Prefabs/Level1/EatS");
        eat_w = Resources.Load<GameObject>("Prefabs/Level1/EatW");
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
	}

    void UpdatePosition()
    {
        Vector3 borderRight = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width,Screen.height/2,10));
        borderRight.x -= 3.2f;
        Vector3 borderLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10));
        borderLeft.x += 3.2f;
        if (right>0)
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
        if(collider.gameObject.tag.Equals(IDRegister .thingTag))
        {
            if (this.gameObject.name.Equals(IDRegister .leftPos))
            {
                UpdateLocalScore(collider.GetComponent<Thing>().PassDamage(true));
                if (collider.GetComponent<Thing>().PassDamage(true) > 0)
                {
                    Instantiate(eat_s, collider.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(eat_w, collider.transform.position, Quaternion.identity);
                }
                gap.score_l = scoreTotal;
                GameObject.Find(IDRegister.CANVAS).transform.Find("LeftScore").GetComponent<TextMeshProUGUI>().text = scoreTotal.ToString();
                if(collider .gameObject .name .Equals("xinfeng"))
                {
                    GameObject.Find("Egg").GetComponent<Egg>().done = true;
                }
            }
            else if(this.gameObject.name.Equals(IDRegister .rightPos))  
            {
                UpdateLocalScore(collider.GetComponent<Thing>().PassDamage(false));
                if (collider.GetComponent<Thing>().PassDamage(false) > 0)
                {
                    Instantiate(eat_s, collider.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(eat_w, collider.transform.position, Quaternion.identity);
                }
                gap.score_r = scoreTotal;
                GameObject.Find(IDRegister.CANVAS).transform.Find("RightScore").GetComponent<TextMeshProUGUI>().text = scoreTotal.ToString();
            }
        }
    }

    void UpdateLocalScore(float a)
    {
        scoreTotal += a;       
    }

}
