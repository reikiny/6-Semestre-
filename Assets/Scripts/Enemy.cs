using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float range;
    public Transform pos;

    private void Update()
    {
        RaycastHit hit;
        bool haveHit = Physics.Raycast(pos.position, pos.forward, out hit, range);
        if (haveHit && Turns.enemyTurn)
        {
            if(hit.collider.CompareTag("Player")){
                print("DEAD");
            }else{

            }
        }
    }
    private void OnDrawGizmos()
    {
        RaycastHit hit;

        bool isHit = Physics.Raycast(pos.position, pos.forward, out hit, range);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(pos.position, pos.forward * hit.distance);
            //Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, raio);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(pos.position, pos.forward * range);
        }

    }
}
