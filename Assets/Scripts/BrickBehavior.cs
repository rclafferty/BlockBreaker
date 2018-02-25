using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour {

    [SerializeField]
    Sprite[] hitSprites;// = new Sprite[3];
    
    public static int numBreakableBricks = 0;

    int maxHits;
    int timesHit;

    LevelManager levelManager;

    public AudioClip crackSound;
    //AudioClip c;

	// Use this for initialization
	void Start () {

        //c = Resources.Load<AudioClip>("Sounds/crack");
        crackSound = Resources.Load<AudioClip>("Sounds/crack");

        //numBreakableBricks++;
        maxHits = Convert.ToInt32(this.gameObject.name[0] - '0');

        if (this.tag == "Breakable")
        {
            numBreakableBricks++;
        }
        
        timesHit = 0;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        //hitSprites = Resources.LoadAll<Sprite>("");
        LoadBricks();
    }

    void LoadBricks()
    {
        Sprite[] o = Resources.LoadAll<Sprite>("SpriteSheets/Bricks");

        hitSprites = new Sprite[3];
        hitSprites[0] = o[0];
        hitSprites[1] = o[1];
        hitSprites[2] = o[2];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void HandleHits()
    {
        //GetComponent<AudioSource>().Play();
        AudioSource.PlayClipAtPoint(crackSound, this.transform.position);

        timesHit++;

        if (timesHit >= maxHits)
        {
            numBreakableBricks--;
            levelManager.BrickDestroyed();
            Destroy(this.gameObject);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
        }
    }
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (this.tag == "Breakable")
            HandleHits();
    }

    //TODO: Remove this method once we actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
