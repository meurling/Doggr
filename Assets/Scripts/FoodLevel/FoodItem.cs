using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodItem : MonoBehaviour {
    public float foodAdd = 0;
    public float socialAdd = 0;
    public float happyAdd = 0;
	// Use this for initialization
	void Start () {
        gameObject.transform.parent.GetChild(1).Find("HungerAdd").GetChild(0).GetComponent<Text>().text = "+F: " + foodAdd;
        gameObject.transform.parent.GetChild(1).Find("SocialAdd").GetChild(0).GetComponent<Text>().text = "+S: " + socialAdd;
        gameObject.transform.parent.GetChild(1).Find("HappyAdd").GetChild(0).GetComponent<Text>().text = "+H: " + happyAdd;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void onClick()
    {
        Dog.feedStatic(foodAdd);
        Dog.socializeStatic(socialAdd);
        Dog.playStatic(happyAdd);
    }
}
