using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public GameObject  player;
    private Vector3 distanceOfPlayer;
    // Start is called before the first frame update
    void Start()
    {
            distanceOfPlayer = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position + distanceOfPlayer;
    }
}
