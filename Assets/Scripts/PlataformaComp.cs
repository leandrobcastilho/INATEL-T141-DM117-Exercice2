using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaComp : MonoBehaviour {

    [SerializeField]
    private bool autoPlay = false;

    private BolaComp bolaComp;

    private Vector2 offset;

    // Use this for initialization
    void Start () {
        bolaComp = FindObjectOfType<BolaComp>();
        offset = bolaComp.transform.position-transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (autoPlay)
        {
            if (bolaComp.JogoComecou)
                MovimentoAutomatico();
        }
        else
        {
            MovimentoMouse();
        }
	}

    private void MovimentoMouse()
    {
        float mousePosWorldUnitX = ((Input.mousePosition.x) / Screen.width * 16);

        Vector2 plataformaPos = new Vector2(0, transform.position.y);

        plataformaPos.x = Mathf.Clamp(mousePosWorldUnitX, 0f, 15f);
        transform.position = plataformaPos;
    }

    private void MovimentoAutomatico()
    {
        float bolaPosWorldUnitX = bolaComp.transform.position.x;

        Vector2 plataformaPos = new Vector2(0, transform.position.y);

        plataformaPos.x = Mathf.Clamp(bolaPosWorldUnitX, 0f, 15f) - offset.x;
        transform.position = plataformaPos;
    }
}
