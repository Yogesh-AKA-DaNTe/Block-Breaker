using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Variables for assigning assets to block
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Variables for storing Level and GameStatus classes
    Level level;
    GameStatus gameStatus;

    // Number of times the block is hit
    int timesHit;

    void Start()
    {
        // Assigning Level and GameStatus
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        // Counting breakable blocks
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    // Checks if the breakable block reached its hit limit 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    // Function for showing next hit sprite of the block
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    // Function for destroying the block and doing necessary gameplay mechanics when it is destroyed
    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        gameStatus.AddToScore();
        level.BlockDestroyed();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    // Function to show VFX when a block breaks
    public void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
