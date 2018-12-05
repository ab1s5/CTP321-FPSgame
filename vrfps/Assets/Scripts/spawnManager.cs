using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy; //Prefab을 받을 public 변수 입니다.
    public int stage;
    public float radius = 50f;
    public Transform playerTr;

    void SpawnEnemy()
    {
        float randomX = Random.Range(-50f, 50f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        float randomZ = Random.Range(0f, 1f);
        float Z;
        if (randomZ >= 0.5f)
        {
            Z = Mathf.Sqrt(2500f - randomX * randomX);
        }
        else
        {
            Z = -Mathf.Sqrt(2500f - randomX * randomX);
        }

        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(playerTr.position.x+randomX, playerTr.position.y, playerTr.position.y+Z), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        }
    }
    void Start()
    {
        playerTr = GameObject.Find("Player").transform;
        stage = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score;
        InvokeRepeating("SpawnEnemy", 3, 3); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
    }
    void Update()
    {

    }
}
