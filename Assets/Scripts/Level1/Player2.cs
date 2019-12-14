using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    private float speed; //移动速度

    private List<GameObject> colliders;

    private Animation an;

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
        an = GetComponent<Animation>();
        speed = 10;
        previousCenter = new Vector3(0, 0, 0);
        _angle_speed = 4f;
    }
    void UpdateAngel() //更新角度 始终保持固定的围绕半径
    {
        center = GameManager.instance.pos2;
        if (Mathf.Abs(center.transform.position.x - previousCenter.x) > 0.1)
        {
            pos = GameManager.instance.pos1;
            _center_pos = center.transform.position;
            temp_angle = -Mathf.Deg2Rad * angle_180((transform.position - center.position), transform.right);
            _pos_new.x = _center_pos.x + Mathf.Cos(temp_angle) * _radius_length;
            _pos_new.y = _center_pos.y + Mathf.Sin(temp_angle) * _radius_length;
            _pos_new.z = transform.localPosition.z;

            transform.localPosition = _pos_new;
            previousCenter = center.position;
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateAngel();
        Move1();
    }

    void Move1() //圆周运动
    {
        if (Input.GetKey(KeyCode.Q))
        {
            temp_angle += _angle_speed * Time.deltaTime;
            _pos_new.x = _center_pos.x + Mathf.Cos(temp_angle) * _radius_length;
            _pos_new.y = _center_pos.y + Mathf.Sin(temp_angle) * _radius_length;
            _pos_new.z = transform.localPosition.z;

            transform.localPosition = _pos_new;
        }
        else if (Input.GetKey(KeyCode.E))
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
        if (collider.tag == "Thing")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                an.Play();
                GameManager.instance.ap.PlayClipAtPoint(GameManager.instance.hit, Camera.main.transform.position);
                collider.GetComponent<Test>().SetPos(pos);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Thing")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                an.Play();
                GameManager.instance.ap.PlayClipAtPoint(GameManager.instance.hit, Camera.main.transform.position);
                collider.GetComponent<Test>().SetPos(pos);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Thing")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                an.Play();
                GameManager.instance.ap.PlayClipAtPoint(GameManager.instance.hit, Camera.main.transform.position);
                collider.GetComponent<Test>().SetPos(pos);
            }
        }
    }

    float angle_180(Vector2 from, Vector2 to)
    {
        Vector3 v3;
        Vector3 v3_from = new Vector3(from.x, from.y, 1);
        Vector3 v3_to = new Vector3(to.x, to.y, 1);
        v3 = Vector3.Cross(v3_from, v3_to);
        if (v3.z > 0)
        {
            return Vector2.Angle(from, to);
        }
        else
        {
            return -Vector2.Angle(from, to);
        }
    }
}
