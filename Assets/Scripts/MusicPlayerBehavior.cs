using UnityEngine;

public class MusicPlayerBehavior : MonoBehaviour {

    // Singleton
    public static MusicPlayerBehavior instance = null;

    private void Awake()
    {
        // If there is already an instance of this object
        if (instance != null)
        {
            // Destroy this instance
            Destroy(this.gameObject);
            print("Duplicate music player self-destructing!");
        }
        // If this is the first instance
        else
        {
            // Save this instance
            instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }
}
