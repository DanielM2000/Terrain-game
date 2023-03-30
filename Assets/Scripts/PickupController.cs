using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PickupController : MonoBehaviour
{
    public GameObject pickupPrefab;
    //private GameObject spawnPoint;
    public int numberOfPickups = 2;
    private GameObject[] spawnPointList;
    private bool[] spawnIndexAvailableList;
    private int numberOfSpawnPoints;
    public int minimumSpawnDelayTime = 1;
    public int maximumSpawnDelayTime = 5;
    private Text textField;
    private int score;
    void UpdateScoreText()
    {
        textField.text = score.ToString();
    }
    //void Awake()
    //{
    // spawnPoint = GameObject.FindWithTag("SpawnPoint");
    // SpawnPickup();
    //}
    void Awake()
    {
        spawnPointList = GameObject.FindGameObjectsWithTag("SpawnPoint") as GameObject[];
        numberOfSpawnPoints = spawnPointList.Length;
        spawnIndexAvailableList = new bool[numberOfSpawnPoints];
        if (numberOfPickups > numberOfSpawnPoints) numberOfPickups = numberOfSpawnPoints;
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            spawnIndexAvailableList[i] = true;
        }
        for (int j = 0; j < numberOfPickups; j++)
        {
            SpawnPickup();
        }
        textField = GameObject.Find("Canvas/txt-score").GetComponent<Text>(); score = 0;
        UpdateScoreText();
    }
    // void SpawnPickup()
    // {
    // Vector3 spawnedPickupPosition = spawnPoint.transform.position;
    // Quaternion spawnedPickupRotation = spawnPoint.transform.rotation;
    // GameObject spawnedPickup = Instantiate(pickupPrefab, spawnedPickupPosition, 
    //spawnedPickupRotation) as GameObject;
 // spawnedPickup.transform.parent = spawnPoint.transform;
 // }
 void SpawnPickup()
    {
        int randomSpawnIndex;
        do
        {
            randomSpawnIndex = Random.Range(0, numberOfSpawnPoints);
        }
        while (spawnIndexAvailableList[randomSpawnIndex] != true);
        Vector3 spawnedPickupPosition = spawnPointList[randomSpawnIndex].transform.position;
        Quaternion spawnedPickupRotation = spawnPointList[randomSpawnIndex].transform.rotation;
        GameObject spawnedPickup = Instantiate(pickupPrefab, spawnedPickupPosition,
       spawnedPickupRotation) as GameObject;
        spawnedPickup.transform.parent = spawnPointList[randomSpawnIndex].transform;
        spawnedPickup.name = randomSpawnIndex.ToString();
        spawnIndexAvailableList[randomSpawnIndex] = false;
    }
    // public void Collected (GameObject pickupCollected)
    public IEnumerator Collected(GameObject pickupCollected)
    {
        int index = int.Parse(pickupCollected.name);
        spawnIndexAvailableList[index] = true;
        score = score + 1;
        UpdateScoreText();
        Destroy(pickupCollected);
        yield return new WaitForSeconds(Random.Range(minimumSpawnDelayTime,
       maximumSpawnDelayTime));
        SpawnPickup();
    }
}

