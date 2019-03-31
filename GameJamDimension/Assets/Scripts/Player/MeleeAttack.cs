using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public string attackKey;

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCoolDown = .3f;

    public BoxCollider2D forwardTrigger;
    public BoxCollider2D backwardTrigger;
    public BoxCollider2D rightTrigger;
    public BoxCollider2D leftTrigger;


    private Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        forwardTrigger.enabled = false;
        backwardTrigger.enabled = false;
        rightTrigger.enabled = false;
        leftTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey) && !attacking)
        {
            attacking = true;
            attackTimer = attackCoolDown;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                forwardTrigger.enabled = false;
                backwardTrigger.enabled = false;
                rightTrigger.enabled = false;
                leftTrigger.enabled = false;
            }

            animator.SetBool("Attacking", attacking);

            if (animator.GetBool("MovingRight")) {
                animator.SetBool("AttackingRight", attacking);
                animator.SetBool("AttackingLeft", false);
                animator.SetBool("AttackingFwd", false);
                animator.SetBool("AttackingBack", false);
                forwardTrigger.enabled = false;
                backwardTrigger.enabled = false;
                rightTrigger.enabled = attacking;
                leftTrigger.enabled = false;
            }
            else if (animator.GetBool("MovingLeft")) {
                animator.SetBool("AttackingLeft", attacking);
                animator.SetBool("AttackingFwd", false);
                animator.SetBool("AttackingBack", false);
                animator.SetBool("AttackingRight", false);
                forwardTrigger.enabled = false;
                backwardTrigger.enabled = false;
                rightTrigger.enabled = false;
                leftTrigger.enabled = attacking;
            }
            else if (animator.GetBool("MovingFwd")) {
                animator.SetBool("AttackingFwd", attacking);
                animator.SetBool("AttackingBack", false);
                animator.SetBool("AttackingRight", false);
                animator.SetBool("AttackingLeft", false);
                forwardTrigger.enabled = attacking;
                backwardTrigger.enabled = false;
                rightTrigger.enabled = false;
                leftTrigger.enabled = false;
            }
            else if (animator.GetBool("MovingBack")) {
                animator.SetBool("AttackingBack", attacking);
                animator.SetBool("AttackingRight", false);
                animator.SetBool("AttackingLeft", false);
                animator.SetBool("AttackingFwd", false);
                forwardTrigger.enabled = false;
                backwardTrigger.enabled = attacking;
                rightTrigger.enabled = false;
                leftTrigger.enabled = false;
            }

        }
    }
}
