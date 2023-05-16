using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllienArea : MonoBehaviour
{

    [Header("ALIEN MOVEMENT")]
    Vector2 direction = Vector2.right;
    [SerializeField] float speed = 1f;

    [SerializeField] Alien[] aliens;
    [SerializeField] int rows = 5, columns = 11;

    [SerializeField] int amountDead;
    const int totalAliens = 55;
    
    public GameObject missilePrefabs;
    [SerializeField] float shootTimer = 3f;
    const float shootTime = 3f;

    public List<GameObject> allAliens = new List<GameObject>();

    public GameObject shipPrefab;
    Vector2 ShipSpawnPos = new Vector2(16.3f, 13.0f);

    UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject alien in  GameObject.FindGameObjectsWithTag("Allien"))
            allAliens.Add(alien);

        uiManager = FindObjectOfType<UIManager>();

        InvokeRepeating(nameof(SpawnShip), 10, Random.Range(10,20));
    }

    
    private void Awake(){
        for (int row = 0; row < rows; row++){ //0,1,2,3,4
            for (int col = 0; col < columns; col++){ //0,1,2,3,4,5,6,7,8,9,10

                Alien alien = Instantiate(aliens[row], transform);

                //CENTRALIZAR A GRADE DE INVADERS
                Vector2 center =  new Vector2(-3, -2);
                Vector2 rowPosition = new Vector2(center.x, center.y + (row * 0.8f));

                Vector2 position = rowPosition;
                position.x += col * 0.8f;
                alien.transform.localPosition = position;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        //CRIANDO A  MOVIMENTAÇÃO DOS INVADERS
        transform.Translate(direction * speed * Time.deltaTime);

        Vector2 leftEdge = Camera.main.ViewportToWorldPoint(Vector2.zero); //pega a borda esquerda - da câmera
        Vector2 rightEdge = Camera.main.ViewportToWorldPoint(Vector2.right); //pega a borda direita - da câmera

        foreach (Transform Alien in transform) //"para cada" alien dentro do objeto de alien_area
        {
            if(direction == Vector2.right && Alien.position.x >= rightEdge.x - 0.5f)
                AdvanceAlien();
            else if(direction == Vector2.left && Alien.position.x <= leftEdge.x + 0.5f)
                AdvanceAlien();
        }

        if (shootTimer <=0)
            EnemyShoot();

        shootTimer -= Time.deltaTime;

    }

    private void EnemyShoot()
    {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;

        Instantiate(missilePrefabs, pos, Quaternion.identity);

        shootTimer = shootTime;
    }

    void AdvanceAlien()
    {
        direction.x *= -1;

        Vector3 position = transform.position;
        position.y -= 0.1f;
        transform.position = position;
    }

    public void AlienKilled()//Faz a contabilidade dos inimigos mortos
    {
        amountDead++;
        speed += 0.2f;

        if (speed >= 2)
            speed = 2;

        if (amountDead >= totalAliens)
        {
            if (uiManager.score > uiManager.hScore)
            {
                PlayerPrefs.SetInt("HScore", uiManager.score); //classe usada para salvar valore de preferencias de usuário
                uiManager.hScoreText.text = uiManager.score.ToString();
            }

            SceneManager.LoadScene("SpaceInvaders");
        }

        
    }

    void SpawnShip()
    {
        Instantiate(shipPrefab, new Vector2(5.6f, 3.9f), Quaternion.identity);
    }
}
