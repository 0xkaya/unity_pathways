using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text CounterText;
    public TMP_Text TimerText;
    public GameObject FruitPrefab;
    public Transform SpawnArea;
    public GameObject GameOverPanel;

    private int count = 0;
    private float timer = 60f; // Game duration in seconds
    private bool isGameActive = true;

    private void Start()
    {
        count = 0;
        UpdateCounter();
        StartCoroutine(SpawnFruits());
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (isGameActive)
        {
            // Timer countdown
            timer -= Time.deltaTime;
            TimerText.text = "Time Left: " + Mathf.Ceil(timer);

            if (timer <= 0)
            {
                GameOver();
            }
        }
    }

    private IEnumerator SpawnFruits()
    {
        while (isGameActive)
        {
            float spawnDelay = Random.Range(0.5f, 1.5f); // Delay between spawns
            yield return new WaitForSeconds(spawnDelay);

            // Spawn fruit at a random position
            Vector3 spawnPosition = new Vector3(
                Random.Range(SpawnArea.position.x - 5, SpawnArea.position.x + 5), 
                SpawnArea.position.y, 
                SpawnArea.position.z
            );
            Instantiate(FruitPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void IncrementCounter()
    {
        count++;
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        CounterText.text = "Fruits Caught: " + count;
    }

    private void GameOver()
    {
        isGameActive = false;
        GameOverPanel.SetActive(true);
        GameOverPanel.GetComponentInChildren<Text>().text = "Game Over! Total Fruits Caught: " + count;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
