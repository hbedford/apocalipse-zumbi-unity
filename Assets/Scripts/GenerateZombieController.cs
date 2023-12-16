using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZombieController : MonoBehaviour
{
    public GameObject Zombie;
    private float counter = 0;
    public float TimeToGenerate = 1;
    public LayerMask LayerZombie;
    private int distanceOfGenerate = 3;
    private int distanceOfPlayer = 20;
    private GameObject player;
    private int amountMaxZombiesAlive = 2;
    private int amountZombiesAlive = 0;
    private float timeToNextLevel = 30;
    private float counterToNextLevel;

    void Start()
    {
       player = GameObject.FindWithTag("Player");
        counterToNextLevel = timeToNextLevel;
        for( int i = 0; i < amountMaxZombiesAlive; i++)
        {
            GenerateNewZombie();
        }
    }
    void Update()
    {
        bool playerIsNotClose = Vector3.Distance(transform.position, player.transform.position) < distanceOfPlayer;

        if (playerIsNotClose || amountMaxZombiesAlive == amountZombiesAlive) return;
        counter += Time.deltaTime;
        if(counter> TimeToGenerate)
        {
            GenerateNewZombie();
            counter = 0;

        }

        if(Time.timeSinceLevelLoad> counterToNextLevel)
        {
            amountMaxZombiesAlive++;
            counterToNextLevel = Time.timeSinceLevelLoad + timeToNextLevel;
        }
    }

    void GenerateNewZombie()
    {
        Vector3 positionToGenerate = RandomPosition();
        Collider[] colliders = Physics.OverlapSphere(positionToGenerate, 1,LayerZombie);
        if(colliders.Length > 0)
        {
            GenerateNewZombie();
            return;
        }
       ZombieController zombie = Instantiate(Zombie, positionToGenerate, transform.rotation).GetComponent<ZombieController>();
        zombie.myGenerate = this;
        amountZombiesAlive++;
    }

    Vector3 RandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * distanceOfGenerate;
        position += transform.position;
        position.y = 0;
        return position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceOfGenerate);
    }

    public void ZombieDie()
    {
        amountZombiesAlive--;
    }
}
