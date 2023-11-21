using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject buyer;

    public Transform buyerSpawnPoint;

    public Transform PosPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    private void Start()
    {
        SpawnBuyer();
    }

    public void SpawnBuyer()
    {
        GameObject buyerSpawned = Instantiate(buyer, buyerSpawnPoint.position, Quaternion.identity) as GameObject;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReSetCurrentLevel()
    {
        //levels[currentIndex].AddComponents();
    }
}