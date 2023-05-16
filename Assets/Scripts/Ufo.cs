using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x <= -5.45)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<UIManager>().UpdateScore(scoreValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
