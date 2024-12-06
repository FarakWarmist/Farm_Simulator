using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Animal
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    Vector3 targetPosition;
    public Bunny()
    {
        SpeedWalk = 6f;
        SpeedRun = SpeedWalk * 3f;
        PerceptionDistance = 8f;
        IsRunning = false;
        MaxHealth = 4f;
        Health = MaxHealth;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Perceive();
        Move();
        FlipSprite();

        if (Health == 0)
        {
            Die();
        }
    }
    public override void Move()
    {
        float moveTime = IsRunning ? 5 : 0;
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, CurrentSpeed * Time.deltaTime);
            string animationToPlay = IsRunning ? "Walk" : "Run";
            animator.SetTrigger(animationToPlay);
        }
        else
        {
            Invoke("ChooseTarget", moveTime);
            animator.SetTrigger("Idle");
        }
    }

    public override void Perceive()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, PerceptionDistance))
        {
            Debug.Log(hit.collider.gameObject);
            var player = hit.collider.GetComponent<PlayerPrefs>();
            if (player != null)
            {
                StartCoroutine(Run());
            }
        }
    }

    public override void ChooseTarget()
    {
        float xRange = Random.Range(-10f, 10f);
        float yRange = Random.Range(-10f, 10f);

        targetPosition = new Vector3(xRange, yRange);
    }

    public override void FlipSprite()
    {
        var velocity = rb.velocity;

        if (velocity.x != 0)
        {
            spriteRenderer.flipX = velocity.x < 0;
        }
    }

    public override void Die()
    {
        Debug.Log("Bunny is dead");
        Destroy(gameObject);
    }

    IEnumerator Run()
    {
        IsRunning = true;
        CurrentSpeed = SpeedRun;
        yield return new WaitForSeconds(Random.Range(3, 8));
        CurrentSpeed = SpeedWalk;
        IsRunning = false;
    }
}
