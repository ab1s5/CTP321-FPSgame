using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public int HP;
	public int score;
    public Transform playerTr;

	protected NavMeshAgent nvAgent;
    protected Animator Ani;
	protected Transform EnemyTr;
	public PlayerCtrl pc;
    public ScoreManager sm;

	// Use this for initialization

    void Awake()
    {
        playerTr = GameObject.Find("Player").transform;
        nvAgent = GetComponent<NavMeshAgent>();
        Ani = GetComponent<Animator>();
        EnemyTr = GetComponent<Transform>();
        nvAgent.destination = playerTr.position;
        StartCoroutine(EnemyState());
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
		pc = GameObject.Find ("Player").GetComponent<PlayerCtrl> ();
    }

    void OnEnable()
    {
        nvAgent.destination = playerTr.position;
    }
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0)
		{
			StopCoroutine(EnemyState());
			StartCoroutine(EnemyDie());
		}
        //player.transform;
	}

    protected virtual IEnumerator EnemyState()
    {
        while (true)
        {
            Ani.SetBool("Attack", false);
            float dist = Vector3.Distance(playerTr.position, EnemyTr.position);
            if (dist <= 20)
            {
				yield return new WaitForSeconds(2f);
				while (true)
				{
					Debug.Log("attack");
					Ani.SetBool("Attack", true);
					pc.GetHit(8);
					yield return new WaitForSeconds(0.5f);
				}
            }
            yield return null;
        }
    }

	protected virtual IEnumerator EnemyDie()
	{
		nvAgent.isStopped = true;
		Ani.SetBool("Hit", true);
		Ani.SetBool("Attack", false);

		yield return new WaitForSeconds(0.3f);
		sm.AddScore(score);
		Destroy(gameObject);
	}
	
}
