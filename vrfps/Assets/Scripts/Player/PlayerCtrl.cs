using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour {

	private Vector3 screenCenter;
    private AudioSource GunShot;
	public GameObject shot;
    private EnemyController ec;
	public int hp;
	public TextMesh gameoverText;
    public GameObject player;

	Coroutine coroutine;
	public ScoreManager sm;


	// Use this for initialization
	void Start () {
		screenCenter = new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        GunShot = GetComponent<AudioSource>();
		sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        if (Variables.stage == 0)
        {
            player.transform.position = new Vector3(0, 0, 0);
        }
        else if (Variables.stage % 3 == 1)
        {
            player.transform.position = new Vector3(0, 0, 0);
        }
        else if (Variables.stage % 3 == 2)
        {
            player.transform.position = new Vector3(126, 0, 145);
        }
        else
        {
            player.transform.position = new Vector3(120, 0, -90);
        }

        coroutine = StartCoroutine(Shooting());
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
		{
			StopCoroutine(coroutine);
			Gameover();
		}
		if (sm.stage == 1 && sm.score >= 100)
		{
			gameObject.transform.position = new Vector3(163, 3.3f, 22);
			sm.stage = 2;
		}
	}

	private IEnumerator Shooting()
	{
		while (true)
		{
			Ray ray = Camera.main.ScreenPointToRay(screenCenter);
			RaycastHit hit;

			if (Input.anyKeyDown)
			{ //vr클릭으로 바꿔야됨
				GunShot.Play();
				if (Physics.Raycast(ray, out hit, 500f))
				{
					if (hit.collider.gameObject.CompareTag("Enemy"))
					{
						ec = hit.collider.gameObject.GetComponent<EnemyController>();
						ec.HP -= 10;
						//ScoreManager.instance.AddScore(10);
					}
                    else if (hit.collider.gameObject.CompareTag("Start"))
                    {
                        Debug.Log("hi");
                        Variables.AddStage();
                        SceneManager.LoadScene("Game");
                    }
                    else if (hit.collider.gameObject.CompareTag("Finish"))
                    {
                        Application.Quit();
                    }

                }
				shot.SetActive(true);
				yield return new WaitForSeconds(0.05f);
				shot.SetActive(false);
				yield return new WaitForSeconds(0.15f);
			}
			yield return null;
		}
	}

	public void GetHit (int damage) {
		hp -= damage;
		Debug.Log("get damage");
	}

	void Gameover ()
	{
		gameoverText.text = "GAME OVER";
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in enemies)
		{
			enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
			if (enemy.name == "enemy1(Clone)")
			{
				enemy.GetComponent<EnemyController>().enabled = false;
				//Debug.Log("1111");
			}
			else if (enemy.name == "enemy2(Clone)") enemy.GetComponent<SelfDestructEnemy>().enabled = false;
			//Destroy(enemy);
		}
	}
}
