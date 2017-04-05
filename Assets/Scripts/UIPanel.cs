using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour {
    public enum Value
    {
        LONLEY,
        HAPPY,
        HUNGER
    };
    public Slider slider;
    public Value valueType = Value.LONLEY;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        setValue();
	}

    public void setValue()
    {
        switch (valueType)
        {
            case Value.LONLEY:
                slider.value = Dog.current.getLonley() / Dog.maxLonley;
                break;
            case Value.HAPPY:
                slider.value = Dog.current.getHappy() / Dog.maxHappy;
                break;
            case Value.HUNGER:
                slider.value = Dog.current.getHunger() / Dog.maxHunger;
                break;
        }
    }
}
