using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Thing[] things;

    public Transform pos1; //右边的点
    public Transform pos2; //左边的点

    public static GameManager instance;
	// Use this for initialization
	void Awake () {
        Init();
        GetCenterPos();
        if (things.Length > 0)
        {
            for (int i = 0; i < things.Length; i++)
            {
                things[i].Init(-10, -10, 1.5f, false, pos1);
            }
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
