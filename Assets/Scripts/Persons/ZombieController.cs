using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    public GameObject Player;
    public float Speed = 5;
    private MovementController movementController;
    private AnimatorController animator;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
       RandomZumbie();
        movementController = GetComponent<MovementController>();
        animator = GetComponent<AnimatorController>();

    }


    void FixedUpdate(){
        Vector3 direction = Player.transform.position - transform.position;

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance >2.5 ){
            
            movementController.Move(direction, Speed);
            movementController.Rotate(direction);

            animator.Attack(false);
        }
        if(distance < 3)
        {
            animator.Attack(true);
            AttackPlayer();
        }
    }


     void AttackPlayer()
    {
        Player.GetComponent<PlayerController>().ReceiveDamage(10);

    }

    void RandomZumbie()
    {
        int randomType = Random.Range(1, 28);
        transform.GetChild(randomType).gameObject.SetActive(true);
    }
}

