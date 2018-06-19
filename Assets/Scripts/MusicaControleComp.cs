using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaControleComp : MonoBehaviour {

    public static MusicaControleComp musicaControleComp = null;

    private void Awake()
    {
        if( musicaControleComp != null)
        {
            Destroy(gameObject);
        }
        else
        {
            musicaControleComp = this;
            DontDestroyOnLoad(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
