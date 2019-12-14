using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private Rigidbody2D p1rb;
    private Rigidbody2D p2rb;
    [SerializeField]
    private float followSpeed;

	// Use this for initialization
	void Start () {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        p1rb = player1.GetComponent<Rigidbody2D>();
        p2rb = player2.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        CameraMove();
        Restart();
	}

    void Follow(Vector2 target,float speed)
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 targetPos = new Vector2(target.x, target.y);
        pos = Vector2.Lerp(pos, targetPos, speed * Time.deltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    void CameraMove()
    {
        if(p1rb.velocity!=Vector2.zero||p2rb.velocity!=Vector2.zero)
        {
            Vector3 pos = (player1.transform.position + player2.transform.position) / 2;
            Follow(pos,followSpeed);
        }
    }

    void Restart()
    {
        if (player1.transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)).y|| player1.transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)).y)
            SceneManager.LoadScene("Level2");
        if (player2.transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)).y || player2.transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -10)).y)
            SceneManager.LoadScene("Level2");
    }

}
