using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAttack : MonoBehaviour
{

    private int ANIM_ATTACK_TRIGGER = Animator.StringToHash("Attack");

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnAttack(InputValue input) {
        animator.SetTrigger(ANIM_ATTACK_TRIGGER);
    }
}
