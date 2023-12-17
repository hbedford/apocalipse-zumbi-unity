using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossController : MonoBehaviour, IHit
{
    private Transform player;
    private NavMeshAgent agent;
    private StatusController statusController;
    private AnimatorController AnimatorController;
    private MovementController movementController;
    private bool isAttacking = false;
    public Slider sliderLife;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        statusController = GetComponent<StatusController>();
        agent.speed = statusController.Speed;
        AnimatorController = GetComponent<AnimatorController>();
        movementController = GetComponent<MovementController>();
        sliderLife.maxValue = statusController.InitialHealth;
        updateLife();

    }

    private void Update()
    {
        agent.SetDestination(player.position);
        AnimatorController.Moving(agent.velocity.magnitude);

        if (!agent.hasPath) return;

        bool isCloseOfPlayer = Vector3.Distance(transform.position, player.position) < agent.stoppingDistance;
        if(isCloseOfPlayer)
        {
            isAttacking = true;
            AnimatorController.Attack(true);
            movementController.Rotate(player.position - transform.position);
            Invoke("AttackPlayer", 1);
            return;
        }
        isAttacking = false;
        AnimatorController.Attack(false);
       
    }

    void AttackPlayer()
    {
        Debug.Log("está atacando");
        if (!isAttacking) return;
        int damage = Random.Range(30, 40);
        player.GetComponent<PlayerController>().Hit(damage);
    }

    public void Hit(int value)
    {
        statusController.LoseHealth(value);
        updateLife();
        if (statusController.Health <= 0)
        {
           Die();
        }
    }

    public void Die()
    {

        AnimatorController.Die();
        this.enabled = false;
        agent.enabled = false;
    }

    void updateLife()
    {
        sliderLife.value = statusController.Health;
    }

}
