using UnityEngine;
using System.Collections;

public class UIView : MonoBehaviour {

    public CanvasGroup canvasGroup;
    public ViewManager.View view;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(ViewManager.current.getCurrentView() == view)
        {
            show();
        }
        else
        {
            hide();
        }
	}

    void hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }

    void show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
