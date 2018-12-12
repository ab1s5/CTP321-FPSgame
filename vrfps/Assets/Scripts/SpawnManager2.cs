using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
	public bool enableSpawn = false;
	public GameObject Enemy; //Prefab을 받을 public 변수 입니다.
	public int stage;
	public float interval;
	public Transform playerTr;

	void SpawnEnemy()
	{
		float radius = 100f;
		float randomAngle = Random.Range(0, 360); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.

		if (enableSpawn)
		{
			GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(playerTr.position.x + radius * Mathf.Cos(randomAngle), 0, playerTr.position.z + radius * Mathf.Sin(randomAngle)), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
		}
	}
	void Start()
	{
		playerTr = GameObject.Find("Player").transform;
		stage = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().score;
		InvokeRepeating("SpawnEnemy", 0, interval); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
	}
	void Update()
	{

	}
}