using System;
using UnityEngine;

public class BrickBehavior : MonoBehaviour {

    // Keep track of sprites for each level of damage
    [SerializeField]
    Sprite[] hitSprites;

    // Track number of breakable bricks still in the scene
    public static int numBreakableBricks = 0;

    // Track max hits allowed for this type of brick
    int maxHits;

    // Track the number of times this brick has been hit
    int timesHit;

    // Pointer to the level manager
    LevelManager levelManager;

    // Pointer to the sound effect that is played when the brick is hit
    public AudioClip crackSound;

	// Use this for initialization
	void Start () {

        // Load the sound effect
        crackSound = Resources.Load<AudioClip>("Sounds/crack");

        // Get the number of hits allowed from the name of the brick
        //     Ex: '1 hit' --> max of 1 hit needed to break it
        //         '2 hit' --> 1 hit to damage it, 1 hit to break it
        //         ...
        maxHits = Convert.ToInt32(this.gameObject.name[0] - '0');

        // If this is a breakable brick, increment the number of breakable bricks created in the scene
        if (this.tag == "Breakable")
        {
            numBreakableBricks++;
        }
        
        timesHit = 0;
        
        // Find the level manager object in the scene
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        
        // Load the brick sprites
        LoadBricks();
    }

    void LoadBricks()
    {
        // Load all brick sprites
        Sprite[] o = Resources.LoadAll<Sprite>("SpriteSheets/Bricks");

        // Store only the relevant brick sprites in the hitSprites array
        hitSprites = new Sprite[3];
        hitSprites[0] = o[0]; // 0 damage
        hitSprites[1] = o[1]; // 1 hit of damage
        hitSprites[2] = o[2]; // 2 hits of damage
    }

    void HandleHits()
    {
        // Play the sound effect
        AudioSource.PlayClipAtPoint(crackSound, this.transform.position);

        // Track number of times this has been hit
        timesHit++;

        // If that's the last hit
        if (timesHit >= maxHits)
        {
            // Destroy this brick
            numBreakableBricks--;
            levelManager.BrickDestroyed();
            Destroy(this.gameObject);
        }
        // Not the last hit
        else
        {
            // Change the sprite
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
