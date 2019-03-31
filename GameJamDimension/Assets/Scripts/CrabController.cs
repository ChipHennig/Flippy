using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabController : MonoBehaviour
{
    public float speed;

    public float lookRadius;

    private Transform target;

    private Rigidbody2D rb2d;

    private Health health;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    private void Update()
    {

        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            float step = speed * Time.deltaTime;
            rb2d.MovePosition(Vector2.MoveTowards(transform.position, target.position, step));
        }

        if(!health.isAlive)
        {
            Destroy(gameObject);
        }
    }

}

