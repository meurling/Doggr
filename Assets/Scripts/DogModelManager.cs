using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DogModelManager : MonoBehaviour {
    public static DogModelManager current;

    public Dictionary<string, GameObject> dogModels = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> hats = new Dictionary<string, GameObject>();

    public List<DictEntry> dogM;
    public List<DictEntry> hatM;

    [Serializable]
    public class DictEntry
    {
        
        public string key;
        public GameObject go;
    }

    void Awake()
    {
        current = this;
        foreach (DictEntry entry in dogM)
        {
            dogModels[entry.key] = entry.go;
        }
        foreach (DictEntry entry in hatM)
        {
            hats[entry.key] = entry.go;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
