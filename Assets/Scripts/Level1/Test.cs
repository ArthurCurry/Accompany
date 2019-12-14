using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Thing{

    // Use this for initialization
    private string posName;
	void Start () {
        targetTime = 0.4f;
        time = targetTime;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        GetPos();
        if (fly)
        {
            Fly();
        }
	}

    public override void Init(bool received , Transform a)//东西飞出初始化
    {
        for(int i=0;i<GameManager .instance.tp.Count; i++)
        {
            if(gameObject .name .Equals (GameManager .instance.tp[i].name))
            {
                this.a_damage = GameManager.instance.tp[i].a_damage;
                this.b_damage = GameManager.instance.tp[i].b_damage;
                this.speed = GameManager.instance.tp[i].speed + (GameManager.instance.status - 1) * 0.25f;
            }
        }
        isLeft = received;
        target = a;
        posName = a.gameObject.name;
        GetPos();
        this.rg = GetComponent<Rigidbody2D>();
        fly = true;
    }
    
    private void GetPos() //检测目标距离
    {
        if (target != null) 
        {
            pos = (target.transform.position - transform.position).normalized; 
        }
        
    }

    public void SetPos(Transform a) //设置目标点位置
    {
        if (time >= targetTime)
        {
            target = a;
            posName = a.gameObject.name;
            speed *= 5;
            isLeft = !isLeft;
            time = 0;
        }

    }

    public override void Fly() //飞向需要的点
    {
        this.transform.Translate( pos * speed * Time .deltaTime);
    }

    public override void Accept()
    {
        //特效生成
        if(gameObject .name .Equals("xinfeng"))
        {
            GameManager.instance.nextLevel = true;
        }
        Destroy(this.gameObject, 0.1f);
    }
    
    public override float PassDamage(bool which_damage)
    {
        if (which_damage) //左
        {
            return a_damage;
        }
        else
        {
            return b_damage;
        }
    }
}
