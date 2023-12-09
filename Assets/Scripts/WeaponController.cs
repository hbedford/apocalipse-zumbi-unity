using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject WeaponPoint;

    public AudioClip audioShot;
 

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.timeScale !=0){
            Instantiate(Bullet, WeaponPoint.transform.position, WeaponPoint.transform.rotation);
            SoundController.instance.PlayOneShot(audioShot);
        }
    }
}
