using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public int HP;
	public int scoreNum;
    public Transform playerTr;

	public LineRenderer attack1;
	public LineRenderer attack2;
	public AudioClip audioAttack;

	protected AudioSource audioSource;

	protected NavMeshAgent nvAgent;
    protected Animator Ani;
	protected Transform EnemyTr;
	public PlayerCtrl pc;

	Coroutine coroutine;

	private int level = 0;
	// Use this for initialization

    void Awake()
    {
        playerTr = GameObject.Find("Player").transform;
        nvAgent = GetComponent<NavMeshAgent>();
        Ani = GetComponent<Animator>();
        EnemyTr = GetComponent<Transform>();
        nvAgent.destination = playerTr.position;
        coroutine = StartCoroutine(EnemyState());
		pc = GameObject.Find ("Player").GetComponent<PlayerCtrl> ();


		audioSource = GetComponent<AudioSource>();
	}

    void OnEnable()
    {
        nvAgent.destination = playerTr.position;
    }

	void OnDisable()
	{
		StopAllCoroutines();
	}

	// Update is called once per frame
	void Update () {
		if (HP <= 0)
		{
			StopCoroutine(coroutine);
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
					pc.GetHit(2*Variables.stage);
					Color c = attack1.material.GetColor("_TintColor");
					c.a = 1f;
					attack1.material.SetColor("_TintColor", c);
					attack2.material.SetColor("_TintColor", c);
					audioSource.clip = audioAttack;
					audioSource.Play();
					for (int i = 0; i < 10; i++)
					{
						c.a -= 0.1f;
						attack1.material.SetColor("_TintColor", c);
						attack2.material.SetColor("_TintColor", c);
						yield return new WaitForSeconds(0.05f);
					}
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
		Variables.AddScore(scoreNum);
		Destroy(gameObject);
	}
	
}
