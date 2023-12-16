using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicKit : MonoBehaviour

{

    private int healAmount = 10;
    private int timeToDestroy = 10;

    private void Start() {
        Destroy(gameObject, timeToDestroy);
    }
        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.Heal(10);
            Destroy(gameObject);
        }
    }
}
