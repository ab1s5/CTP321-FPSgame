using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPTextManager : MonoBehaviour {

    public TextMesh HPText;
	public PlayerCtrl pc;
	// Use this for initialization
	void Start () {
		pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
		HPText.text = "HP : " + pc.hp;
	}
}
