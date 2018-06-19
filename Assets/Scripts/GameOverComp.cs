using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverComp : MonoBehaviour {

    
    private LevelControllerComp levelControllerComp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelControllerComp.CarregaLevel("TelaGameOver");
    }

	// Use this for initialization
	void Start () {
        levelControllerComp = FindObjectOfType<LevelControllerComp>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
