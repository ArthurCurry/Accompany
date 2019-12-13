using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : Thing{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (fly)
        //{
        //    Fly(pos);
        //}
	}

    public override void Init(float aDamage, float bDamage, float speed ,bool received , Vector2 a)//东西飞出初始化
    {
        this.a_damage = aDamage;
        this.b_damage = bDamage;
        this.speed = speed;
        isA = received;
        pos = a;
        this.rg = GetComponent<Rigidbody2D>();
        Invoke("T", 2);
    }
    
    private void T()
    {
        this.rg.velocity = pos * speed ;
        //this.fly = true;
    }

    public override void Fly(Vector2 a) //飞向需要的点
    {
        //this.transform.Translate(a * speed * Time.deltaTime);
        this.rg.velocity = a * speed * 10;
    }

    public override void Accept()
    {
        //受到对应的伤害
        Destroy(this.gameObject, 0.1f);
    }
    
}
