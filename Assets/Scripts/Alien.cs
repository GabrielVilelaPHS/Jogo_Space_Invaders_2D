using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;

    [Header("ANIMATE SPRITE")]
    [SerializeField] int index;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float time;
    SpriteRenderer sR; //componente que está no objeto

    AllienArea allienArea;
    UIManager uiManager;

    public int scoreValue;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        allienArea = FindObjectOfType<AllienArea>();

        uiManager = FindObjectOfType<UIManager>();

        InvokeRepeating(nameof(AnimateAlien), time, time);
    }

    public void DestroyAlien()
    {
        FindObjectOfType<UIManager>().UpdateScore(scoreValue);
        allienArea.allAliens.Remove(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); //insancio o game object, na posição do alien e em rotação
        allienArea.AlienKilled();
        gameObject.SetActive(false);
    }

    void AnimateAlien()
    {

        index++;

        if(index >= sprites.Length)
            index = 0;

        sR.sprite = sprites[index];    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            if (uiManager.score > uiManager.score)
            {
                PlayerPrefs.SetInt("HScore", uiManager.score);  
                uiManager.hScoreText.text = uiManager.score.ToString();
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
