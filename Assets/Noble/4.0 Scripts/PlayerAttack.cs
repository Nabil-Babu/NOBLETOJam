using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAttack : MonoBehaviour
{

    private int ANIM_ATTACK_TRIGGER = Animator.StringToHash("Attack");

    public Animator animator;

    public HammerControls hammer;  



    // Start is called before the first frame update
    void Start()
    {
        hammer = GetComponentInChildren<HammerControls>();
    }

    public void OnAttack(InputValue input) {
        animator.SetTrigger(ANIM_ATTACK_TRIGGER);
        Invoke("SwingHammer", 0.5f);
        
    }

    public void SwingHammer()
    {
        hammer.KillTarget();
    }
}
