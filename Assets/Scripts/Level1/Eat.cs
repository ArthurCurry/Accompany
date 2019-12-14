using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat :MonoBehaviour {

    void _Destroy()
    {
        GameObject.Destroy(this.gameObject,0.1f);
    }
}
