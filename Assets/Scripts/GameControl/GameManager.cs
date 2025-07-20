using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform playerLocation;
    
    private float spawnInterval;
    private bool areSpawning;
    
    private float currentScore;
    private float highscore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");
        UIManagerTD.Instance.UpdateHighscore(highscore);
    }

    private void InitializeGame()
    {
        currentScore = 0;
        UIManagerTD.Instance.UpdateScore(currentScore);
        areSpawning = true;
        spawnInterval = 5f;
        StartCoroutine(SpawnEnemies());
    }
    
    private IEnumerator SpawnEnemies()
    {
        while (areSpawning)
        {
            Enemy enemy = Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
            enemy.target = playerLocation;
        
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval -= 0.05f;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        int randomSide = Random.Range(1, 5);

        float xPosition = 0, yPosition = 1, zPosition = 0;

        switch (randomSide)
        {
            case 1:
                zPosition = 45f;
                xPosition = Random.Range(-45f, 45f);
                break;
            case 2:
                zPosition = Random.Range(-45f, 45f);
                xPosition = -45f;
                break;
            case 3:
                zPosition = -45f;
                xPosition = Random.Range(-45f, 45f);
                break;
            case 4:
                zPosition = Random.Range(-45f, 45f);
                xPosition = 45f;
                break;
        }

        return new Vector3(xPosition, yPosition, zPosition);
    }
    
    public void StopSpawning()
    {
        areSpawning = false;
        
        // Clear all remaining enemies
        Enemy[] allEnemies = Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy enemy in allEnemies)
        {
            Destroy(enemy.gameObject);
        }
        
        if (currentScore > highscore) SaveHighscore();
    }

    private void SaveHighscore()
    {
        highscore = currentScore;
        UIManagerTD.Instance.UpdateHighscore(highscore);
        PlayerPrefs.SetFloat("HIGHSCORE", highscore);
    }
    
    public void IncreaseScore()
    {
        currentScore += 10;
        UIManagerTD.Instance.UpdateScore(currentScore);
    }
    
    public void PlayGame()
    {
        UIManagerTD.Instance.ShowGameView();
        InitializeGame();
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
