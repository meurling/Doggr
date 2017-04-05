using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadLevelOnClick : MonoBehaviour {
    public Collider coll;
    public string levelName;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            RaycastHit[] rayHit = Physics.RaycastAll(ray);
            float dist = float.PositiveInfinity;
            bool shouldStart = false;
            foreach (RaycastHit hit in rayHit)
            {
                if(dist > hit.distance && coll == hit.collider)
                {
                    shouldStart = true;
                }
                else if(dist > hit.distance && hit.collider != coll)
                {
                    shouldStart = false;
                }
                dist = Mathf.Min(dist, hit.distance);
            }
            if (shouldStart)
            {
                onClick();
            }
            
        }
	}

    void onClick()
    {
        SceneManager.LoadScene(levelName);
    }
}
