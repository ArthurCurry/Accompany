using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;//移动速度
    [SerializeField]
    private float jumpVector;//跳跃初始速度
    [SerializeField]
    private float jumpTime;//控制跳跃时间
    private float originalGravityScale;
    //private float timer;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Jump()
    {
        StartCoroutine(JumpCoroutine(jumpVector));
    }

    void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        if (rb.velocity.y==0f)
        {
            rb.velocity = new Vector2(moveSpeed * direction, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space)&&rb.velocity.y==0)
        {
            Jump();
            
        }
    }

    IEnumerator JumpCoroutine(float jumpStartSpeed)
    {
        float timer = 0f;
        rb.gravityScale = 0f;
        while(timer<jumpTime)
        {
            float dampTime = timer / jumpTime;
            Vector2 jumpSpeed = Vector2.Lerp(jumpStartSpeed * Vector2.up, Vector2.zero, dampTime);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed.y);
            timer += Time.deltaTime;
            if (rb.velocity.y == 0)
                StopAllCoroutines();
            yield return null;
        }
        rb.gravityScale = originalGravityScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if(collision.collider.gameObject.tag.Equals("Floor"))
        {
            StopAllCoroutines();
            rb.gravityScale = originalGravityScale;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
