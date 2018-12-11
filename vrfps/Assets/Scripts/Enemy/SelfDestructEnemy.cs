using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEnemy : EnemyController {

	protected override IEnumerator EnemyState()
	{
		while (true)
		{
			Ani.SetBool("Attack", false);
			float dist = Vector3.Distance(playerTr.position, EnemyTr.position);
			if (dist <= 10)
			{
				nvAgent.isStopped = true;
				yield return new WaitForSeconds(1f);
				//ani.setbool("runjump", true); //터지는 이펙트

				audioSource.clip = audioAttack;
				audioSource.Play();
				pc.GetHit(30);
				Debug.Log("detonate");
				gameObject.transform.position = new Vector3(0, -1000, 0);
				yield return new WaitForSeconds(2f);
				Destroy(gameObject);
			}
			yield return null;
		}
	}
}
