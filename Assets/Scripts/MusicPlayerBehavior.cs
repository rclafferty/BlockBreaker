using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerBehavior : MonoBehaviour {

    public static MusicPlayerBehavior instance = null;

    private void Awake()
    {
        //Debug.Log("Music player awake, ID code: " + GetInstanceID());
        if (instance != null)
        {
            Destroy(this.gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
