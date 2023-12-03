using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateZombieController : MonoBehaviour
{
    public GameObject Zombie;
    private float counter = 0;
    public float TimeToGenerate = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter> TimeToGenerate)
        {
            counter = 0;
            Instantiate(Zombie, transform.position, transform.rotation);

        }
    }
}
