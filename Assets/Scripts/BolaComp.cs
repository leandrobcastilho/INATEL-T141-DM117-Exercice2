using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaComp : MonoBehaviour {

    private AudioSource audioSource;

    private PlataformaComp plataformaComp;

    private Rigidbody2D rv2D;

    private bool jogoComecou = false;
    public bool JogoComecou
    {
        get
        {
            return jogoComecou;
        }
    }

    private Vector3 plataformaBolaDis;

	// Use this for initialization
	void Start () {
        rv2D = GetComponent<Rigidbody2D>();
        plataformaComp = FindObjectOfType<PlataformaComp>();
        plataformaBolaDis = transform.position - plataformaComp.transform.position;
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if( !jogoComecou)
        {
            transform.position = plataformaComp.transform.position + plataformaBolaDis;
            if(Input.GetMouseButton(0))
            {
                rv2D.velocity = new Vector2(2f, 12f);
                jogoComecou = true;
            }

        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jogoComecou)
        {
            Vector2 velocidadeAjuste = new Vector2(Random.Range(0f, 5f), 0);
            rv2D.velocity += velocidadeAjuste;
            audioSource.Play();
        }
    }
}
