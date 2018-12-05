using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructEnemy : EnemyController {

	public override IEnumerator EnemyState()
	{
		while (true)
		{
			Ani.SetBool("Attack", false);
			float dist = Vector3.Distance(playerTr.position, EnemyTr.position);
			if (dist <= 5)
			{
				pc.GetHit (30);
			}

			if (HP == 0)
			{
				nvAgent.isStopped = true;
				Ani.SetBool("Hit", true);
				Ani.SetBool("Attack", false);

				yield return new WaitForSeconds(1f);
				gameObject.SetActive(false);
				sm.AddScore(100);
			}
			yield return null;
		}
	}
}
