using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    public GameObject Player;
    public float Speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        int randomType = Random.Range(1, 28);
        transform.GetChild(randomType).gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void FixedUpdate(){
        Vector3 direction = Player.transform.position - transform.position;

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance >2.5 ){
            
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction.normalized *Speed * Time.deltaTime));
            Quaternion rotate = Quaternion.LookRotation(direction);
            GetComponent<Rigidbody>().MoveRotation(rotate);

            GetComponent<Animator>().SetBool("attack", false);
        }
        if(distance < 3)
        {
            GetComponent<Animator>().SetBool("attack", true);
        }
    }

    void AttackPlayer()
    {
        Time.timeScale = 0;
        Player.GetComponent<PlayerController>().TextGameOver.SetActive(true);
        Player.GetComponent<PlayerController>().IsLive = false;

    }
}
