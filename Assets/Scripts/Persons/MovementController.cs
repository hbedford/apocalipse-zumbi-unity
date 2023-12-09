using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

   public void Move(Vector3 direction, float speed){
        rigidBody.MovePosition(rigidBody.position + (direction.normalized *speed * Time.deltaTime));
    }

    public void Rotate(Vector3 direction)
    {
        Quaternion newRotation = Quaternion.LookRotation(direction);
        rigidBody.MoveRotation(newRotation);
    }
}
