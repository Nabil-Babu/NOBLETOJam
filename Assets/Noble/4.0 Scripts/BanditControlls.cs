using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BanditControlls : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;
    private bool isAlive = true; 

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
        if(isAlive)
        {
            agent.destination = player.position;
            float aniVel = agent.velocity.magnitude;
            aniVel = Mathf.Clamp(aniVel * 10, 0, 1);
            animator.SetFloat("Blend", aniVel);
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
}
