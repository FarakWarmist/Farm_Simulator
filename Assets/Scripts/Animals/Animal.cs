using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    private float speedWalk;
    private float speedRun;
    private float currentSpeed;
    private float perceptionDistance;
    private bool isRunning;
    private float maxHealth;
    private float health;

    public float SpeedWalk
    { get { return speedWalk; } set {  speedWalk = value; } }

    public float SpeedRun
    { get { return speedRun; } set { speedRun = value; } }

    public float CurrentSpeed
    { get { return currentSpeed; } set { currentSpeed = value; } }

    public float PerceptionDistance
    { get { return perceptionDistance; } set { perceptionDistance = value; } }

    public bool IsRunning
    { get { return isRunning; } set { isRunning = value; } }

    public float MaxHealth
    { get { return maxHealth; } set { maxHealth = value; } }

    public float Health
    {
        get { return health; }
        
        set
        {
            if (health < 0)
            {
                health = 0;
            }
            else if (health > maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health = value;
            }
        }
    }


    public abstract void Move();

    public abstract void Perceive();

    public abstract void ChooseTarget();

    public abstract void FlipSprite();

    public abstract void Die();
}
