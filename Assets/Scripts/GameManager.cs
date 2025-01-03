using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject block;
    public float maxX;
    //生成點
    public Transform spawnPoint;
    //每個箱子的產生率(幾秒後產生下個箱子)
    public float spawnRate;

    bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    int score = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
        }
    }

    private void StartSpawning()
    {   
        //第一次會在調用此方法後0.5秒的時候啟用，後根據spawnRate設定的數值，不斷調用SpawnBlock
        InvokeRepeating("SpawnBlock" , 0.5f , spawnRate) ;
    }


    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX , maxX);

        Instantiate(block , spawnPos , Quaternion.identity);

        score++;

        scoreText.text = score.ToString();
    }
}
