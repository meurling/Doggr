using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

    public static Dog current;
    public float loneliness = 100, hunger = 100, happiness = 100;
    private const float lonelinessDecay = 1, hungerDecay = 1, happinessDecay = 1;

    public const float maxLonley = 100, maxHunger = 100, maxHappy = 100;
    void Awake()
    {
        if(gameObject.tag == "Player")
        {
            current = this;
            hunger = PlayerPrefs.GetFloat("hunger", 100);
            loneliness = PlayerPrefs.GetFloat("lonesliness", 100);
            happiness = PlayerPrefs.GetFloat("happiness", 100);
        }
        
    }
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        feed(-hungerDecay * (Time.deltaTime / 60 * 60));
        socialize(-lonelinessDecay * (Time.deltaTime / 60 * 60));
        play(-happinessDecay * (Time.deltaTime / 60 * 60));
	}

    public void feed(float add = 30)
    {
        //Debug.Log("Feed: " + add);
        hunger += add;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);
    }
    public void socialize(float add = 30)
    {
        //Debug.Log("Socialize: " + add);
        loneliness += add;
        loneliness = Mathf.Clamp(loneliness, 0, maxLonley);
    }
    public void play(float add = 30)
    {
        //Debug.Log("Play: " + add);
        happiness += add;
        happiness = Mathf.Clamp(happiness, 0, maxHappy);
    }

    void OnDestroy()
    {
        if(gameObject.tag == "Player")
        {
            Debug.Log("Destroy gameobject");
            PlayerPrefs.SetFloat("hunger", hunger);
            PlayerPrefs.SetFloat("loneliness", loneliness);
            PlayerPrefs.SetFloat("happiness", happiness);
        }
    }

    public float getLonley()
    {
        return loneliness;
    }
    public float getHappy()
    {
        return happiness;
    }
    public float getHunger()
    {
        return hunger;
    }

    //On Buttons this is the function that must be called.
    //the current thing doesn't seem to be a reference.
    public static void feedStatic(float add = 30)
    {
        if (current == null)
        {
            float hunger = PlayerPrefs.GetFloat("hunger", 100);
            PlayerPrefs.SetFloat("hunger", Mathf.Clamp(hunger + add, 0, 100));
            return;
        }

        current.feed(add);
    }
    /**
        The static versions of feed/socialize/play does not require an active Playerdog.
    */
    public static void socializeStatic(float add = 30)
    {
        if (current == null)
        {
            float loneliness = PlayerPrefs.GetFloat("loneliness", 100);
            PlayerPrefs.SetFloat("loneliness", Mathf.Clamp(loneliness + add, 0, 100));
            return;
        }

        current.socialize(add);
    }
    public static void playStatic(float add = 30)
    {
        if (current == null)
        {
            float happiness = PlayerPrefs.GetFloat("happiness", 100);
            PlayerPrefs.SetFloat("happiness", Mathf.Clamp(happiness + add, 0, 100));
            return;
        }

        current.play(add);
    }
}
