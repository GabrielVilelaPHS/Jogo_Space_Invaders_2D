using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllienBullets : MonoBehaviour
{
    [SerializeField] float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= -5.27f)
            Destroy(gameObject);
    }
}
