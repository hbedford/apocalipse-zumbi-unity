using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 20;
    // Start is called before the first frame update
    public AudioClip AudioKill;
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
        if(other.gameObject.tag == "Inimigo")
        {
            Destroy(other.gameObject);
            SoundController.instance.PlayOneShot(AudioKill);

        }
        Destroy(gameObject);
    }
   
}
