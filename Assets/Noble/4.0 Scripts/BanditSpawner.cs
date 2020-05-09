using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditSpawner : MonoBehaviour
{

    public GameObject bandit;
    public GameObject[] spawnPoints; 

    private GameObject[] banditsOnScreen;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBandit();
    }

    // Update is called once per frame
    void Update()
    {
        banditsOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
        if(banditsOnScreen.Length <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                GenerateBandit();
            }
        }
    }

    void GenerateBandit()
    {
        Vector3 spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        Instantiate(bandit, spawnLocation, Quaternion.identity);
    }
}
