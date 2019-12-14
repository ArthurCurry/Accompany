using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Thing[] things;

    public Transform pos1; //左边的点
    public Transform pos2; //右边的点

    public static GameManager instance;
	// Use this for initialization
	void Awake () {
        Init();
        GetCenterPos();
        if (things.Length > 0)
        {            
            things[0].Init(1, 10000, 1, true, pos1);
            //things[0].Fly(p);
        }
	}
	
    void Init()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }

	// Update is called once per frame
	void Update () {
        GetCenterPos();
	}

    void GetCenterPos()
    {
        pos1 = GameObject.Find(IDRegister .rightPos).transform;
        pos2 = GameObject.Find(IDRegister .leftPos).transform;
    }
}
