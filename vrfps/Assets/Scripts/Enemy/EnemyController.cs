using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public int HP;
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
        StartCoroutine(EnemyState());
    }
	
	// Update is called once per frame
	void Update () {
        //player.transform;
	}

    public virtual IEnumerator EnemyState()
    {
        while (true)
        {
            Ani.SetBool("Attack", false);
            float dist = Vector3.Distance(playerTr.position, EnemyTr.position);
            if (dist <= 20)
            {
                Debug.Log("attack");
                Ani.SetBool("Attack", true);
            }

            if (HP <= 0)
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
