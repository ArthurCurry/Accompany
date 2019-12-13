using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed; //移动速度

    public Transform pos;

    public Transform center;

    //
    public float _radius_length;
    public float _angle_speed;

    private float temp_angle;

    private Vector3 _pos_new;

    public Vector3 _center_pos;

    public bool _round_its_center;
    // Use this for initialization
    void Start () {
        speed = 10;
        _center_pos = center.transform.position;
        _angle_speed = 4f;
        _radius_length = Vector3.Distance(transform .position, center.position);

        temp_angle = -Mathf.Deg2Rad * Vector2.Angle((transform .position -center .position),transform.right );

    }
	
	// Update is called once per frame
	void Update () {
        Move1();
	}

    void Move1() //圆周运动
    {
        if(Input .GetKey(KeyCode.Q))
        {
            temp_angle += _angle_speed * Time.deltaTime;
            _pos_new.x = _center_pos.x + Mathf.Cos(temp_angle) * _radius_length;
            _pos_new.y = _center_pos.y + Mathf.Sin(temp_angle) * _radius_length;
            _pos_new.z = transform.localPosition.z;

            transform.localPosition = _pos_new;
        }
        else if(Input .GetKey(KeyCode.E))
        {
            temp_angle -= _angle_speed * Time.deltaTime;
            _pos_new.x = _center_pos.x + Mathf.Cos(temp_angle) * _radius_length;
            _pos_new.y = _center_pos.y + Mathf.Sin(temp_angle) * _radius_length;
            _pos_new.z = transform.localPosition.z;

            transform.localPosition = _pos_new;
        }
        
    }

    void Move()
    {
        if(Input .GetKey (KeyCode.W))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        else if(Input .GetKey(KeyCode.S))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        else if(Input .GetKey (KeyCode.A))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        else if(Input .GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider .tag == "Thing")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Vector2 a = (pos.position - collider.transform.position).normalized;
                collider.GetComponent<Test>().Fly(a);
            }
        }
    }
}
