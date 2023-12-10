using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZombieController : MonoBehaviour
{
    public GameObject Zombie;
    private float counter = 0;
    public float TimeToGenerate = 1;
    public LayerMask LayerZombie;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        Instantiate(Zombie, positionToGenerate, transform.rotation);
    }

    Vector3 RandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * 3;
        position += transform.position;
        position.y = 0;
        return position;
    }
}
