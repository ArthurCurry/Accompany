using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Thing : MonoBehaviour{

    protected float speed; //飞行速度
    protected float a_damage; //对a的伤害
    protected float b_damage; //对b的伤害

    protected bool fly;
    protected Transform target;
    protected Vector2 pos;

    protected Rigidbody2D rg;

    public bool isA; //判断谁可以接收


    public enum type //东西的类型
    { 

    
    }

    public abstract void Init(float aDamage, float bDamage, float speed ,bool received , Transform a); //东西飞出初始化

    public abstract void Fly(); //飞向需要的点

    public abstract void Accept();
}
