using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingProperty{

    public string name;
    public float a_damage;
    public float b_damage;
    public float speed;

    public ThingProperty(string n ,float a, float b, float s)
    {
        this.name = n;
        this.a_damage = a;
        this.b_damage = b;
        this.speed = s;
    }

}
