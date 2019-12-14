using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed; //移动速度

    private List<GameObject> colliders;

    public Transform pos;

    public Transform center;
    [SerializeField]
    private Vector3 previousCenter; //判断中心有没有动

    // 绕圆周运动
    public float _radius_length;
    public float _angle_speed;

    private float temp_angle;

    private Vector3 _pos_new;

    public Vector3 _center_pos;
    // Use this for initialization

    void Start()
    {
        speed = 10;
        colliders = new List<GameObject>();
        previousCenter = new Vector3(0, 0, 0);
        _angle_speed = 4f;
    }
    void UpdateAngel() //更新角度 始终保持固定的围绕半径
    {
        center = GameManager.instance.pos2;
        if (Mathf .Abs(center.transform.position.x - previousCenter.x)>0.1)
        {
            pos = GameManager.instance.pos1;
            _center_pos = center.transform.position;
            temp_angle = -Mathf.Deg2Rad * Vector2.Angle((transform.position - center.position), transform.right);
            _pos_new.x = _center_pos.x + Mathf.Cos(temp_angle) * _radius_length;
            _pos_new.y = _center_pos.y + Mathf.Sin(temp_angle) * _radius_length;
            _pos_new.z = transform.localPosition.z;

            transform.localPosition = _pos_new;
            previousCenter = center.position;
        }
    }

	
	// Update is called once per frame
	void Update () {
        UpdateAngel();
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
    void OnTriggerStay2D(Collider2D collider)
    {
        float distance = 0;
        GameObject target = null;
        if(collider .tag == "Thing")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                colliders.Add(collider.gameObject);
                if(colliders.Count > 0)
                {
                    for(int i=0; i < colliders.Count; i++)
                    {
                        if(distance <= Vector2 .Distance (transform .position ,colliders[i].transform .position))
                        {
                            target = colliders[i];
                            distance = Vector2.Distance(transform.position, colliders[i].transform.position);
                        }
                    }
                    target.GetComponent<Test>().SetPos(pos);
                }
            }
        }
    }
}
