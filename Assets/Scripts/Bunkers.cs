using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunkers : MonoBehaviour
{
    public Sprite[] states;
    int health;
    SpriteRenderer sr;

    // Start is called before the first frame update
    private void Start()
    {
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Allien"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<AllienArea>().allAliens.Remove(collision.gameObject);
        }

        if(collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            health--;

            if (health > 0)
                sr.sprite = states[health - 1];
            else
                Destroy(gameObject);
        }

        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
