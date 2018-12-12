using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMesh scoreText;
    public int score;
    public int stage;

	public GameObject spawnmanager;
	void Awake()
    {
        score = 0;
        stage = 1;
        if (!instance)
            instance = this;
    }

    public void AddScore(int num)
    {
        score += num*stage;
        scoreText.text = "Score : " + score;
    }

    void Start()
    {

    }

    void Update()
    {
		if (stage == 2)
		{
			spawnManager[] sm = spawnmanager.GetComponents<spawnManager>();
			foreach (spawnManager _sm in sm) _sm.enableSpawn = false;
			spawnmanager.GetComponent<SpawnManager2>().enableSpawn = true;
		}
    }
}