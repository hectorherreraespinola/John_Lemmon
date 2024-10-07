using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    private bool isPlayerInRange;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    private void Update()
    {
        if(isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(origin: transform.position, direction);
            //Drawing gizmos
            Debug.DrawRay(transform.position,direction, Color.red, 0.5f);
            
            RaycastHit raycastHit;
            
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, player.position);   
    }
}
