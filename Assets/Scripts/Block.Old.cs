using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOld : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 1;
    [SerializeField] Sprite[] damageSprites;

    Level level;
    GameSession gameStatus;
    int timesHit = 0;    

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        if (level != null && tag.ToLower() != "unbreakable")
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag.ToLower() == "breakable")
        {
            timesHit++;
            if (timesHit == maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = 0;

        if ((timesHit / maxHits) > .75)
        {
            spriteIndex = 1;
        }

        if ((timesHit + 1) == maxHits)
        {
            spriteIndex = damageSprites.Length - 1;
        }

        GetComponent<SpriteRenderer>().sprite = damageSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerSparklesVFX();
        level.RemoveBlock();
        Destroy(gameObject, 0.1f);
        gameStatus.AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles,1f);
    }
}
