using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject WeaponPoint;
    // Start is called before the first frame update

    public AudioClip audioShot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Instantiate(Bullet, WeaponPoint.transform.position, WeaponPoint.transform.rotation);
            SoundController.instance.PlayOneShot(audioShot);
        }
    }
}
