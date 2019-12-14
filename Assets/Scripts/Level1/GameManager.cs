using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public List <Thing> thingsleft;
    public List <Thing> thingsright;

    public Thing xin;

    public int status; //判断是第几波

    private bool count;

    public float time;
    public float animationTime;
    private float targetTime;

    public bool startFly;

    public GameObject image2;
    public bool nextLevel;

    public List<ThingProperty> tp;

    public Transform pos1; //右边的点
    public Transform pos2; //左边的点

    public static GameManager instance;
    public AudioPlay ap;
    public AudioClip hit;
	// Use this for initialization
	void Awake () {
        Init();
        InitTP();
        GetCenterPos();
	}
	
    void Init()
    {
        if(instance ==null)
        {
            instance = this;
        }
        ap = new AudioPlay();
    }

	// Update is called once per frame
	void Update () {
        if (count)
        {
            UpadateTime();
        }
        GetCenterPos();
        if (startFly)
        {
            MakeThingsFly();
        }
        ChangeLevel();
	}

    void GetCenterPos()
    {
        pos1 = GameObject.Find(IDRegister .rightPos).transform;
        pos2 = GameObject.Find(IDRegister .leftPos).transform;
    }

    void InitTP()
    {
        status = 1;
        startFly = false;
        nextLevel = false;
        time = 0;
        animationTime = 0;
        targetTime = 6;
        count = true;
        image2 = GameObject.Find(IDRegister.CANVAS).transform.Find("Image2").gameObject;
        hit = ap.AddAudioClip("Audio/off");
        if(tp==null)
        {
            tp = new List<ThingProperty>();
;       }
        if (thingsleft == null)
        {
            thingsleft = new List<Thing>();
;
        }
        if (thingsright == null)
        {
            thingsright = new List<Thing>();
;
        }
        tp.Add(new ThingProperty("shoushi", -1, 1, 1.1f));
        tp.Add(new ThingProperty("shu", 1, -1, 1.1f));
        tp.Add(new ThingProperty("zuichun", -1, 1, 1.1f));
        tp.Add(new ThingProperty("tiaoseban", -1, 1, 1.1f));
        tp.Add(new ThingProperty("qunzi", 1, -1, 1.1f));
        tp.Add(new ThingProperty("liushengji", -1, 1, 1.1f));
        tp.Add(new ThingProperty("baozhi", -1, 1, 1.1f));
        tp.Add(new ThingProperty("huoyan", 1, -1, 1.1f));
        tp.Add(new ThingProperty("shouji", 1, -1, 1.1f));
        tp.Add(new ThingProperty("xinfeng", 0, 0, 1.1f));
        string l = "LeftThings";
        string r = "RightThings";
        int a = 0;
        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                thingsleft.Add(GameObject.Find(l + a.ToString()).transform.GetChild(i).GetComponent<Thing>());
                thingsright.Add(GameObject.Find(r + a.ToString()).transform.GetChild(i).GetComponent<Thing>());
            }
            a++;
        }
    }

    void UpadateTime()
    {
        animationTime += Time.deltaTime;
        time += Time.deltaTime;
    }

    void MakeThingsFly()
    {
        if (time >= targetTime && status <= 6)
        {
            for(int i= 0;i < 4; i++)
            {
                if (thingsleft[0] != null)
                {
                    pos2 = GameObject.Find(IDRegister.leftPos).transform;
                    thingsleft[0].Init(true, pos2);
                    thingsleft.RemoveAt(0);
                }
                if(thingsright [0]!=null)
                {
                    pos1 = GameObject.Find(IDRegister.rightPos).transform;
                    thingsright[0].Init(false, pos1);
                    thingsright.RemoveAt(0);
                }
            }
            status += 1;
            time = 0;
        }
        else if(time >= targetTime && status == 7)
        {
            xin.Init(false, pos1);
        }
    }

    void ChangeLevel()
    {
        if(status == 7 && nextLevel)
        {
            image2.SetActive(true);
        }
    }
}
