using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Thing{

	// Use this for initialization
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

    public override void Init(float aDamage, float bDamage, float speed ,bool received , Transform a)//东西飞出初始化
    {
        this.a_damage = aDamage;
        this.b_damage = bDamage;
        this.speed = speed;
        isLeft = received;
        target = a;
        GetPos();
        this.rg = GetComponent<Rigidbody2D>();
        fly = true;
    }
    
    private void GetPos() //检测目标距离
    {
        pos = (target.position - transform.position).normalized;
        
    }

    public void SetPos(Transform a) //设置目标点位置
    {
        if (time >= targetTime)
        {
            target = a;
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
