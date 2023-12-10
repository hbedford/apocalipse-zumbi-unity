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

    void Start()
    {
       player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < distanceOfPlayer) return;
        counter += Time.deltaTime;
        if(counter> TimeToGenerate)
        {
            GenerateNewZombie();
            counter = 0;

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
        Instantiate(Zombie, positionToGenerate, transform.rotation);
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
}
