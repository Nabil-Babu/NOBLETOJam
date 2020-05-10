using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class BanditControlls : MonoBehaviour
{
    [Header("Settings")]
    public float minAttackDistance;
    public float attackCoolDown;

    [Header("States")]
    [SerializeField]
    private bool isAttacking = false;
    [SerializeField]
    private bool isAlive = true;


    [Header("Dependencies")]
    public LayerMask AttackingLayer;
    public Animator animator;
    public Transform player;
    private NavMeshAgent agent;
    public GameObject attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            agent.destination = player.position;
            float aniVel = agent.velocity.magnitude;
            aniVel = Mathf.Clamp(aniVel * 10, 0, 1);
            animator.SetFloat("Blend", aniVel);
            if (agent.remainingDistance < minAttackDistance && agent.remainingDistance > 0)
            {
                if (!isAttacking)
                {
                    Attack();
                    isAttacking = true;
                    agent.isStopped = true;
                }
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }

    public void PlayDeathAnim()
    {
        animator.SetTrigger("Death");
        isAlive = false;
        Invoke("Death", 5.0f);
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        Invoke("CheckForPlayer", 0.5f);
        StartCoroutine(AttackTimer());
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(attackCoolDown);
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.transform.position, attackPoint.transform.localScale);
    }

    private void CheckForPlayer()
    {
        Collider[] hitColliders = Physics.OverlapBox(attackPoint.transform.position, attackPoint.transform.localScale, Quaternion.identity, AttackingLayer);
        if (hitColliders.Length > 0)
        {
            Debug.Log("Hit Player");
        }
    }
}
