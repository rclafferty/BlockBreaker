using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBrickBehavior : MonoBehaviour {

    Sprite[] sprites;

	// Use this for initialization
	void Start () {
        sprites = Resources.LoadAll<Sprite>("SpriteSheets/Bricks");
        Debug.Log(sprites.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
