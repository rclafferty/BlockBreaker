using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour {

    // Track the mouse position for paddle movement
    Vector3 mousePosition;
	
	// Update is called once per frame
	void Update () {
        // Mouse movement controls paddle movement
        mousePosition = Input.mousePosition;
        this.transform.position = new Vector3(mousePosition.x / Screen.width * 16, this.transform.position.y) ;
	}
}
