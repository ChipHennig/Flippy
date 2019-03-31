using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public string thisScene;

    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private BoxCollider2D collider;


    public string bellySlideKey;
    private float bellySlideCooldown = 1f;
    private float bellySlideTimer = 0;
    private bool bellySliding = false;


    public float speed;

    private float moveHorizontal;

    private float moveVertical;

    private Health health;

    private bool canMove;


	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        collider = GetComponent<BoxCollider2D>();
        canMove = true;
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            if (moveHorizontal > 0)
            {
                animator.SetBool("MovingRight", true);
                animator.SetBool("MovingLeft", false);
                animator.SetBool("MovingFwd", false);
                animator.SetBool("MovingBack", false);
            }
            else if (moveHorizontal < 0)
            {
                animator.SetBool("MovingLeft", true);
                animator.SetBool("MovingFwd", false);
                animator.SetBool("MovingBack", false);
                animator.SetBool("MovingRight", false);

            }
            else if (moveVertical < 0)
            {
                animator.SetBool("MovingFwd", true);
                animator.SetBool("MovingBack", false);
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", false);
            }
            else if (moveVertical > 0)
            {
                animator.SetBool("MovingBack", true);
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", false);
                animator.SetBool("MovingFwd", false);
            }

            if (!bellySliding)
            {
                rb2d.MovePosition(rb2d.position + (new Vector2(moveHorizontal, moveVertical) * speed * Time.fixedDeltaTime));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.isAlive)
        {
            SceneManager.LoadScene(thisScene);
        }

        if (canMove)
        {
            if (Input.GetKeyDown(bellySlideKey) && !bellySliding)
            {
                bellySliding = true;
                bellySlideTimer = bellySlideCooldown;
                collider.enabled = false;
                if (animator.GetBool("MovingLeft"))
                {
                    rb2d.velocity = -(transform.right * speed);
                }
                else
                {
                    rb2d.velocity = transform.right * speed;
                }
            }

            if (bellySliding)
            {
                if (bellySlideTimer > 0)
                {
                    bellySlideTimer -= Time.deltaTime;
                }
                else
                {
                    bellySliding = false;
                    collider.enabled = true;
                    animator.SetBool("BellySliding", false);
                    rb2d.velocity = new Vector2(0, 0);
                }

                animator.SetBool("BellySliding", bellySliding);

                if (animator.GetBool("MovingRight"))
                {
                    animator.SetBool("BellySlidingRight", bellySliding);
                    animator.SetBool("BellySlidingLeft", false);
                }
                else if (animator.GetBool("MovingLeft"))
                {
                    animator.SetBool("BellySlidingLeft", bellySliding);
                    animator.SetBool("BellySlidingRight", false);
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if(collisionObject.CompareTag("Enemy")) {
            health.takeDamage(1);
            Debug.Log(health.health);
        }
    }

    public bool ableToMove
    {
        get
        {
            return canMove;
        }

        set
        {
            canMove = value;
        }
    }
}
