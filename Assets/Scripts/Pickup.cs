using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public int numSpawnPoints;
    public Transform[] spawnPoints;

    public Text countText;
    private int score;

    void Awake()
    {
        Debug.Log("Pickup script instance created.");
        score = 0;
        Debug.Log("Initial score: " + score);
        UpdateScoreText();

        spawnPoints = new Transform[numSpawnPoints];
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = spawnPointObjects[i].transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 randomPosition = spawnPoints[randomIndex].position;
            Instantiate(this.gameObject, randomPosition, Quaternion.identity);
            
            score = score +1;
            Debug.Log("Score: " + score);
            
            UpdateScoreText();

            StartCoroutine(RespawnCrate());
            gameObject.SetActive(false);
        }
    }

    void UpdateScoreText()
    {
        // update textfield with score
        Debug.Log("Updating score text...");
        countText.text = score.ToString();
    }

    IEnumerator RespawnCrate()
    {
        yield return new WaitForSeconds(2.0f); // wait for 2 seconds
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 randomPosition = spawnPoints[randomIndex].position;
        gameObject.SetActive(true);
        transform.position = randomPosition;
    }

}
