using UnityEngine;
using UnityEditor;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    void Update()
    {
        // If in the unity editor, NOT deployed application
#if UNITY_EDITOR
        // Load the next level if W key is pressed
        //     Used for debugging
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoadNextLevel();
        }
#endif
    }

    /// <summary>
    /// Tracks number of bricks left in the scene
    /// </summary>
    public void BrickDestroyed()
    {
        if (BrickBehavior.numBreakableBricks <= 0)
        {
            LoadNextLevel();
        }
    }

    /// <summary>
    /// Loads the requested level
    /// </summary>
    /// <param name="name">Name of level to load</param>
    public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

    /// <summary>
    /// Handles exiting the application based on platform
    /// </summary>
	public void QuitRequest(){
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// Loads next level based on build index
    /// </summary>
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
