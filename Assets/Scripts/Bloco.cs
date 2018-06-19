using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private ParticleSystem explosion;

    private AudioSource audioSource;

    public static int numBlocosDestrutivel = 0;

    private int numHits;

    private SpriteRenderer spriteRenderer;

    private LevelControllerComp levelControllerComp;

    // Use this for initialization
    void Start()
    {
        numHits = 0;
        levelControllerComp = FindObjectOfType<LevelControllerComp>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        if (transform.CompareTag("Destrutivel"))
        {
            numBlocosDestrutivel++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.CompareTag("Destrutivel"))
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            EfeitoExplosao();
            TratarDano();
        }
    }

    private void EfeitoExplosao()
    {
        ParticleSystem ps = Instantiate<ParticleSystem>(explosion, transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = ps.main;
        main.startColor = spriteRenderer.color;
    }

    private void TratarDano()
    {
        numHits++;
        int maxHits = sprites.Length + 1;
        if (numHits >= maxHits)
        {
            numBlocosDestrutivel--;
            levelControllerComp.BlocoDestruido();
            Destroy(gameObject);
        }
        else
        {
            CarregaSprite();
        }
    }

    private void CarregaSprite()
    {
        int spriteIndex = numHits-1;
        if (sprites[spriteIndex])
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    void vitoriaFake()
    {
        levelControllerComp.CarregaProxLevel();
    }
}
