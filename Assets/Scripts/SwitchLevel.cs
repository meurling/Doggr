using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void switchLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
