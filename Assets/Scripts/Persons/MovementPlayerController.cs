using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerController : MovementController
{
    public void RotatePlayer(LayerMask groundMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        RaycastHit rayHit;

        if (Physics.Raycast(ray, out rayHit, 100, groundMask))
        {
            Vector3 playerDirectionPosition = rayHit.point - transform.position;
            playerDirectionPosition.y = transform.position.y;
            Rotate(playerDirectionPosition);

        }
    }
}
