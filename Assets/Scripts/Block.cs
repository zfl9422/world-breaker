using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject impactVFX;
    [SerializeField] Sprite[] blockDamage;

    // cache reference
    Level level;
    GameState gameState;

    // debug purposes
    [SerializeField] int timesHit;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameState = FindObjectOfType<GameState>();

        // Only counting breakable blocks
        if (tag == "Breakable")
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only removing breakable blocks
        if (tag == "Breakable")
        {
            OnHit();
        }
    }

    private void OnHit()
    {
        timesHit++;
        int blockHealth = blockDamage.Length + 1;
        if (timesHit >= blockHealth)
        {
            RemoveBlock();
        }
        else
        {
            NextBlockDamageSprite();
        }
        // Score is added per hit, even for blocks with multiple levels of health
        AddToScore();
    }

    private void NextBlockDamageSprite()
    {
        int damageIndex = timesHit - 1;
        if (blockDamage[damageIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = blockDamage[damageIndex];
        }

        // Finding which game object is giving an error
        // Debug.LogError(gameObject.name);

    }

    private void RemoveBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);
        level.RemoveBlock();
        impactTriggerVFX();
    }

    private void AddToScore()
    {
        gameState.ScoreUpdate();
    }

    private void impactTriggerVFX()
    {
        GameObject impact = Instantiate(impactVFX, transform.position, transform.rotation);
        Destroy(impact, 1f);
    }
}
