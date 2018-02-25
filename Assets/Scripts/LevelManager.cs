using UnityEngine;
//using UnityEditor;
using System.Collections;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    void Update()
    {
        Debug.Log(BrickBehavior.numBreakableBricks);
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoadNextLevel();
        }
#endif
    }

    public void BrickDestroyed()
    {
        if (BrickBehavior.numBreakableBricks <= 0)
        {
            LoadNextLevel();
        }
    }

    public void LoadLevel(string name){
		//Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
        //Debug.Log ("Quit requested");
//#if UNITY_EDITOR
        //EditorApplication.isPlaying = false;
//#else
        Application.Quit();
//#endif
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
