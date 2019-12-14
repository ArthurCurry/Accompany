using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;//移动速度
    [SerializeField]
    private float jumpVector;//跳跃初始速度
    [SerializeField]
    private float jumpTime;//控制跳跃时间
    private float originalGravityScale;
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode right;
    [SerializeField]
    private KeyCode jump;
    //private float timer;
    private Vector2 direction;
    [SerializeField]
    private string otherPlayerTag;
    private GameObject otherPlayer;
    [SerializeField]
    private float maxDis;
    [SerializeField]
    private float minDis;
    [SerializeField]
    private float minJumpTime;
    [SerializeField]
    private float maxJumpTime;
    private SpriteRenderer sprite;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
        otherPlayer = GameObject.FindWithTag(otherPlayerTag);
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Jump()
    {
        UpdateJumpTime();
        StartCoroutine(JumpCoroutine(jumpVector));
    }

    void Move()
    {
        if(Input.GetKey(left)&& rb.velocity.y == 0f)
        {
            direction = Vector2.left;
            rb.velocity = direction * moveSpeed;
        }
        if(Input.GetKey(right)&& rb.velocity.y == 0f)
        {
            direction = Vector2.right;
            rb.velocity = direction * moveSpeed;
        }
        if(Input.GetKeyDown(jump)&&rb.velocity.y==0)
        {
            Jump();
        }
    }

    IEnumerator JumpCoroutine(float jumpStartSpeed)
    {
        float timer = 0f;
        rb.gravityScale = 0f;
        float velocityX = rb.velocity.x;
        while(timer<jumpTime)
        {
            float dampTime = timer / jumpTime;
            Vector2 jumpSpeed = Vector2.Lerp(jumpStartSpeed * Vector2.up, Vector2.zero, dampTime);
            rb.velocity = new Vector2(velocityX/3, jumpSpeed.y);
            timer += Time.deltaTime;
            if (rb.velocity.y == 0)
                StopAllCoroutines();
            yield return null;
        }
        rb.gravityScale = originalGravityScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.name);
        if(collision.collider.gameObject.tag.Equals("Floor"))
        {
            StopAllCoroutines();
            rb.gravityScale = originalGravityScale;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    
    void UpdateJumpTime()
    {
        float disBetweenPlayers = (this.transform.position - otherPlayer.transform.position).magnitude;
        jumpTime = disBetweenPlayers * (maxJumpTime - minJumpTime) / (maxDis - minDis);
        if (disBetweenPlayers >= maxDis)
            jumpTime = maxJumpTime;
        if (disBetweenPlayers <= minDis)
            jumpTime = minJumpTime;
    }

    void Die()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(DieCoroutine(4f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Trap"))
        {
            Die();
        }
    }

    IEnumerator DieCoroutine(float dieTime)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Debug.Log(sprite.color.a);
        while(sprite.color.a>0.01f)
        {
            float originalTrans = sprite.color.a;
            float transparency = Mathf.Lerp(originalTrans, 0f, Time.deltaTime * dieTime);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, transparency);
                
            yield return null;
        }
        SceneManager.LoadScene("Level2");
    }

}
