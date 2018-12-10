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
				pc.GetHit(30);
				Debug.Log("detonate");
				Destroy(gameObject);
			}
			yield return null;
		}
	}
}
