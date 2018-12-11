using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {


	private Vector3 screenCenter;
    private AudioSource GunShot;
	public GameObject shot;
    private EnemyController ec;
	public int hp = 100;

    // Use this for initialization
    void Start () {
		screenCenter = new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        GunShot = GetComponent<AudioSource>();
		
		StartCoroutine(Shooting());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator Shooting()
	{
		while (true)
		{
			Ray ray = Camera.main.ScreenPointToRay(screenCenter);
			RaycastHit hit;

			if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
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

}
