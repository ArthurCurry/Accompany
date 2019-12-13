using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Thing{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
        isA = received;
        target = a;
        GetPos();
        this.rg = GetComponent<Rigidbody2D>();
        fly = true;
    }
    
    private void T()  //测试用
    {
        this.rg.velocity = pos * speed ;
        //this.fly = true;
    }

    private void GetPos()
    {
        pos = (target.position - transform.position).normalized;
        
    }

    public void SetPos(Transform a)
    {
        target  = a;
        speed *= 5;
    }

    public override void Fly() //飞向需要的点
    {
        this.transform.Translate( pos * speed * Time .deltaTime);
    }

    public override void Accept()
    {
        //受到对应的伤害
        Destroy(this.gameObject, 0.1f);
    }
    
}
