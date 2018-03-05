using UnityEngine;

public class LoseColliderBehavior : MonoBehaviour {

    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

    /// <summary>
    /// Handles a lose event
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerEnter2D (Collider2D c)
    {
        // If a ball hits this collider, it means the ball fell out of the scene and the player loses
        levelManager.LoadLevel("Lose Screen");
    }

    /// <summary>
    /// Placeholder method for handling collisions instead of triggers
    /// </summary>
    void OnCollision2D()
    {
        print("Collision");
    }
}
