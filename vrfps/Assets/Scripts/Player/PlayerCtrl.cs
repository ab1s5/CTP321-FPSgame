using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

	private Vector3 screenCenter;
    private AudioSource GunShot;
    private EnemyController ec;
	public int hp;

    // Use this for initialization
    void Start () {
		screenCenter = new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        GunShot = GetComponent<AudioSource>();

		hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (screenCenter);

		RaycastHit hit;

		if (Input.GetMouseButtonDown(0)) { //vr클릭으로 바꿔야됨
            GunShot.Play();
            if (Physics.Raycast (ray, out hit, 500f)) {
				if (hit.collider.gameObject.CompareTag ("Enemy"))
                {
                    ec = hit.collider.gameObject.GetComponent<EnemyController>();
                    ec.HP -= 10;
                    ScoreManager.instance.AddScore(10);
                }
					
			}
		}
	}

	public void GetHit (int damage) {
		hp -= damage;
	}

}
