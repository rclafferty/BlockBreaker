using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColliderBehavior : MonoBehaviour {

    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D c)
    {
        //print("Trigger");
        levelManager.LoadLevel("Lose Screen");
    }

    void OnCollision2D()
    {
        print("Collision");
    }
}
