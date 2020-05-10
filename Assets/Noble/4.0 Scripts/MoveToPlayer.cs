using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;

    [Header("Dependencies")]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        float aniVel = agent.velocity.magnitude;
        aniVel = Mathf.Clamp(aniVel * 10, 0, 1);
        animator.SetFloat("Blend", aniVel);
    }

    public void PlayDeath()
    {
        animator.SetTrigger("Death");
    }
}
