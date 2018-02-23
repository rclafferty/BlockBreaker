using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour {

    Vector3 mousePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition;//GameObject.Find("Ball").transform.position;
        //print(mousePosition.x);
        this.transform.position = new Vector3(mousePosition.x / Screen.width * 16, this.transform.position.y) ;
	}
}
