using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewManager : MonoBehaviour {
    public static ViewManager current;
    public enum View
    {
        FRONT,
        LEFT,
        RIGHT,
        EMPTY
    }
    public class ViewNode
    {
        public Vector3 position;
        public Vector3 rotation;
        public View view;
        public ViewNode(Vector3 pos, Vector3 rot, View v)
        {
            position = pos;
            rotation = rot;
            view = v;
        }
    }

    private View currentView;
    private List<ViewNode> viewNodes;
    void Awake()
    {
        current = this;
        viewNodes = new List<ViewNode>();
        currentView = View.FRONT;
    }

    // Use this for initialization
    void Start () {
        Camera.main.transform.position = getPositionForView(View.FRONT);
        Camera.main.transform.localEulerAngles = getEulerForView(View.FRONT);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(viewNodes.Count == 0)
        {
            return;
        }
        ViewNode viewNode = getFirstView();
        float dist = Vector3.Distance(viewNode.position, Camera.main.transform.position);
        if(viewNodes.Count > 1 && dist < 1.0f)
        {
            //Change "currentView"
            viewNode = changeCurrentView();
        }
        if(viewNodes.Count < 2 && dist < 0.1f)
        {
            viewNode = changeCurrentView();
        }
        Vector3 newRot = Camera.main.transform.localEulerAngles;
        Vector3 wantedRotation = viewNode.rotation;
        float t = Time.deltaTime * 2;
        newRot.x = Mathf.LerpAngle(newRot.x, wantedRotation.x, t);
        newRot.y = Mathf.LerpAngle(newRot.y, wantedRotation.y, t);
        newRot.z = Mathf.LerpAngle(newRot.z, wantedRotation.z, t);
        Camera.main.transform.localEulerAngles = newRot;

        Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, viewNode.position, t);
        /*
        Vector3 newRot = Camera.main.transform.localEulerAngles;
        float t = Time.deltaTime * 2;
        newRot.x = Mathf.LerpAngle(newRot.x, wantedRotation.x, t);
        newRot.y = Mathf.LerpAngle(newRot.y, wantedRotation.y, t);
        newRot.z = Mathf.LerpAngle(newRot.z, wantedRotation.z, t);

        Camera.main.transform.localEulerAngles = newRot;
        */
    }

    private ViewNode changeCurrentView()
    {
        if (viewNodes.Count == 0)
        {
            return getViewNode(currentView);
        }
        viewNodes.RemoveAt(0);
        if(viewNodes.Count == 0)
        {
            return getViewNode(currentView);
        }
        for(int i = 0; i < viewNodes.Count; i++)
        {
            if(viewNodes[i].view != View.EMPTY)
            {
                currentView = viewNodes[i].view;
                break;
            }
        }
        return viewNodes[0];
    }

    private ViewNode getFirstView()
    {
        if (viewNodes.Count == 0)
        {
            return getViewNode(currentView);
        }
        return viewNodes[0];
    }

    public void changeView(View view)
    {
        //viewNodes.Add(getViewNode(view));
        getNodeForView(view);
        
    }

    public View getCurrentView()
    {
        return currentView;
    }

    private void getNodeForView(View view)
    {
        if(view == View.RIGHT)
        {
            viewNodes.Add(new ViewNode(new Vector3(-5.9f, 1.0f, -0.07f), getEulerForView(view), View.EMPTY));
            viewNodes.Add(getViewNode(view));
        }
        else if(view == View.LEFT)
        {
            viewNodes.Add(new ViewNode(new Vector3(-2.06f, 1.0f, 0.07f), getEulerForView(view), View.EMPTY));
            viewNodes.Add(getViewNode(view));
        }
        else
        {
            if(currentView == View.LEFT)
            {
                viewNodes.Add(new ViewNode(new Vector3(-2.06f, 1.0f, 0.07f), getEulerForView(view), View.EMPTY));
            }else if(currentView == View.RIGHT)
            {
                viewNodes.Add(new ViewNode(new Vector3(-5.9f, 1.0f, -0.07f), getEulerForView(view), View.EMPTY));
            }
            viewNodes.Add(new ViewNode(new Vector3(-3.9f, 1.0f, -1.84f), getEulerForView(view), view));
            viewNodes.Add(getViewNode(view));
        }
    }

    private Vector3 getEulerForView(View v)
    {
        if (v == View.FRONT)
        {
            return new Vector3(0, -180, 0);
        }
        else if (v == View.LEFT)
        {
            return new Vector3(0, 82.94f, 0);
        }

        return new Vector3(0, -72, 0);
    }
    private ViewNode getLastViewNode()
    {
        if(viewNodes.Count == 0)
        {
            return getViewNode(currentView);
        }
        return viewNodes[viewNodes.Count - 1];
    }

    private ViewNode getViewNode(View v)
    {
        return new ViewNode(getPositionForView(v), getEulerForView(v), v);
    }
    private Vector3 getPositionForView(View v)
    {
        if(v == View.FRONT)
        {
            return new Vector3(-3.86f, 1.0f, -2.97f);
        }
        if(v == View.LEFT)
        {
            return new Vector3(-1.89f, 1.0f, 0.47f);
        }
        return new Vector3(-7.5f, 1.0f, 0.22f);
    }
}
