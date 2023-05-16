using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{    
    [SerializeField] float seconds;
    //[SerializeField] float shootTimer = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, seconds);
    }

}
