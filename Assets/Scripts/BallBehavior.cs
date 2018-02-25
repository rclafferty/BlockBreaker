using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    bool hasStarted;

    PaddleBehavior paddle;
    Vector3 paddleToBallVector;
    Rigidbody2D body;

	// Use this for initialization
	void Start () {
        paddle = GameObject.Find("Paddle").GetComponent<PaddleBehavior>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        //print(paddleToBallVector);
        body = this.GetComponent<Rigidbody2D>();
        hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
            this.transform.position = paddle.transform.position + paddleToBallVector;

        if (Input.GetMouseButtonDown(0))
        {
            //print("Launch ball");

            hasStarted = true;
            body.velocity = new Vector2(2f, 10f);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            if (collision.collider.name == "Paddle")
            {
                body.velocity = new Vector2(10 * (this.transform.position.x - paddle.transform.position.x), Mathf.Max(body.velocity.y, 8f));
            }
            else if (collision.collider.tag == "Breakable")
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
