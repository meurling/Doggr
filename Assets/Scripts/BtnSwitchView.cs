using UnityEngine;
using System.Collections;

public class BtnSwitchView : MonoBehaviour
{

    public enum BtnType
    {
        RIGHT, LEFT
    };
    public BtnType btnType;
    public CanvasGroup canvasGroup;
    void FixedUpdate()
    {
        //Hide the buttons when we are on the "edges"
        if (btnType == BtnType.RIGHT)
        {
            if (ViewManager.current.getCurrentView() == ViewManager.View.RIGHT)
            {
                hide();
            }
            else
            {
                show();
            }
        }
        else
        {
            if (ViewManager.current.getCurrentView() == ViewManager.View.LEFT)
            {
                hide();
            }
            else
            {
                show();
            }
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

    public void clickBtn()
    {
        if (btnType == BtnType.RIGHT)
        {
            if (ViewManager.current.getCurrentView() == ViewManager.View.FRONT)
            {
                ViewManager.current.changeView(ViewManager.View.RIGHT);
            }
            else if (ViewManager.current.getCurrentView() == ViewManager.View.LEFT)
            {
                ViewManager.current.changeView(ViewManager.View.FRONT);
            }
        }
        else
        {
            if (ViewManager.current.getCurrentView() == ViewManager.View.FRONT)
            {
                ViewManager.current.changeView(ViewManager.View.LEFT);
            }
            else if (ViewManager.current.getCurrentView() == ViewManager.View.RIGHT)
            {
                ViewManager.current.changeView(ViewManager.View.FRONT);
            }
        }
    }
}
