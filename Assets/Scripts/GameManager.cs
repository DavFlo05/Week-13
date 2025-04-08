using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject CoinPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI ScoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        UpdateScoreText();
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateEnemy2", 2, 6);
        InvokeRepeating("SpawnCoin", 5f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }
    void CreateEnemy2()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }
    void SpawnCoin()
    {
        float x = Random.Range(-horizontalScreenSize * 0.9f, horizontalScreenSize * 0.9f);
        float y = Random.Range(-4.3f, 1f);
        Instantiate(CoinPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
        
    }
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score;
    }
    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}
