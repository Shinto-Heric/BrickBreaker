using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    [SerializeField] GameObject particle;

    [SerializeField] Sprite[] blockSprite;

    [SerializeField] int totalHits;

    Level level;
    GameStatus gameStatus;


    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.IncrementBreakCount();
        }
        gameStatus = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if (tag == "Breakable")
        {
            totalHits++;
            int maxHits = blockSprite.Length + 1;
            if (totalHits >= maxHits)
            {
                Collided();
                gameStatus.AddScore();
            }
            else
            {
                if(blockSprite[totalHits -1] != null)
                {
                    GetComponent<SpriteRenderer>().sprite = blockSprite[totalHits - 1];
                }
                else
                {
                    Debug.Log("Sprite NOT FOUND" + gameObject.name);
                }
                
            }

        }
        
    }

    private void Collided()
    {
        Destroy(gameObject);
        level.BlockDestroyed();
        PlayParticleEffets();
    }

    private void PlayParticleEffets()
    {
        GameObject sparkle = Instantiate(particle,transform.position,transform.rotation);
        Destroy(sparkle,2f);
    }
}
