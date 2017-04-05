using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogModel : MonoBehaviour {
    public string dogName;
    public GameObject hat;
    public GameObject dogModel;

    private Dictionary<string, GameObject> dogModels;
    private Dictionary<string, GameObject> hats;
    private const string dogKeyPrefix = "dog_model_", hatKeyPrefix = "hat_model_";
    // Use this for initialization
    void Start () {
        dogModels = DogModelManager.current.dogModels;
        hats = DogModelManager.current.hats;
        setModel(PlayerPrefs.GetString(dogKeyPrefix + dogName, "default"));
        setHat(PlayerPrefs.GetString(hatKeyPrefix + dogName, "default"));
	}
	

    public void setModel(string key)
    {
        if (dogModels.ContainsKey(key))
        {
            PlayerPrefs.SetString(dogKeyPrefix + dogName, key);
            dogModel = dogModels[key];
        }
    }

    public void setHat(string key)
    {
        if (hats.ContainsKey(key))
        {
            PlayerPrefs.SetString(hatKeyPrefix + dogName, key);
            hat = hats[key];
        }
    }
}
