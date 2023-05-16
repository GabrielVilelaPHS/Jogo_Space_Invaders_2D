using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("NOME PLAYER")]
    [SerializeField] float speed; //SerializeField exibi no inspetor mas não permite ser acessada em outros scripts
    [SerializeField] float hMove, vMove;

    [Header("PLAYER BULLETS")]
    [SerializeField] GameObject bulletPrefab;

    [Header("LIMITS")]
    const float minX = -4.5f;
    const float maxX = 4.5f;
    const float minY = -4.5f;
    const float maxY = -2.3f;

    [SerializeField] float fireRate = 0.5f, nextFire;

    UIManager uiManager;
    //ctrl + k + c : comentario em bloco

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();

        uiManager.score = 0;
        uiManager.scoreText.text = uiManager.score.ToString();

        uiManager.hScore = PlayerPrefs.GetInt("HScore"); //atribi o que está salvo va variavel/preferencia HSCore
        uiManager.hScoreText.text = uiManager.hScore.ToString("000");
    }

    void Start()
    {
        
    }

    void Update()
    {
        #region //Mover PLAYER jeito 2
        // if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //     transform.Translate(speed * Time.deltaTime * Vector2.right);

        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //     transform.Translate(speed * Time.deltaTime * Vector2.left);
        #endregion

        #region //Mover o PLAYER jeito 2
        hMove = Input.GetAxisRaw("Horizontal");
        vMove = Input.GetAxisRaw("Vertical");

        transform.Translate(hMove * speed * Time.deltaTime * Vector2.right);
        transform.Translate(vMove * speed * Time.deltaTime * Vector2.up);
        #endregion

        //Limitar PLAYER:
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY));

        //TIRO DO PLAYER LIMITADO
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) &&  Time.time >= nextFire)
            Shoot();
    }

    private void Shoot(){
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Allien") || collision.CompareTag("EnemyBullet"))
        {
            if (uiManager.score > uiManager.hScore)
            {
                PlayerPrefs.SetInt("HScore", uiManager.score);
                uiManager.hScoreText.text = uiManager.score.ToString();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }
}
