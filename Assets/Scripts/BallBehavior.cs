using UnityEngine;

public class BallBehavior : MonoBehaviour {

    // Flag to track if the game has started or not
    bool hasStarted;
    
    // Hold pointer to paddle object
    PaddleBehavior paddle;
    
    // Track distance between paddle and ball
    Vector3 paddleToBallVector;
    
    // Hold pointer to rigidbody attached to ball object
    Rigidbody2D body;

	// Use this for initialization
	void Start () {
    
        // Find the paddle object in the scene
        paddle = GameObject.Find("Paddle").GetComponent<PaddleBehavior>();
        
        // Find initial distance between ball and paddle
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
        // Get rigidbody of ball
        body = this.GetComponent<Rigidbody2D>();
        hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        // If ball has not been initially launched
        if (!hasStarted)
            this.transform.position = paddle.transform.position + paddleToBallVector;

        // Handle mouse click event
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
        
            // Launch upwards and slightly to the right
            body.velocity = new Vector2(2f, 10f);
        }
	}

    /// <summary>
    /// Handles a collision between the ball and any other object in the scene
    /// </summary>
    /// <param name="collision">Information about the collision event</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only handle collisions when the ball is actively in play
        if (hasStarted)
        {
            // Handle ball behavior when colliding with the paddle
            if (collision.collider.name == "Paddle")
            {
                body.velocity = new Vector2(10 * (this.transform.position.x - paddle.transform.position.x), Mathf.Max(body.velocity.y, 8f));
            }
            // Handle ball behavior when colliding with any breakable brick
            //     Can be expanded if I choose to add other types of breakable objects
            else if (collision.collider.tag == "Breakable")
            {
                // Play the sound effect
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
