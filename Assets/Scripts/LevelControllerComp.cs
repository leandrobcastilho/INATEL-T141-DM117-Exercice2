using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControllerComp : MonoBehaviour {

	public void CarregaLevel(string sceneNome)
    {
        Bloco.numBlocosDestrutivel = 0;
        SceneManager.LoadScene(sceneNome);
    }

    public void CarregaProxLevel()
    {
        Bloco.numBlocosDestrutivel = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void BlocoDestruido()
    {
        if( Bloco.numBlocosDestrutivel <= 0)
        {
            CarregaProxLevel();
        }
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}
}
