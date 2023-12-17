using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class BulletController : MonoBehaviour
{
    public float Speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position+ transform.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        Quaternion rotation = Quaternion.LookRotation(-transform.forward);
        switch (other.gameObject.tag )
        {
            case "Inimigo":
                ZombieController zombie = other.gameObject.GetComponent<ZombieController>();
                zombie.Hit(10);
                zombie.ParticleBlood(transform.position,rotation);

                break;

            case "Boss":
                other.gameObject.GetComponent<BossController>().Hit(10);
                break;

        }
        Destroy(gameObject);
    }
   
}
