using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public float range;
    public Transform pos;
    public float cooldown;
    float currentCd;

    private void Update()
    {
        //fazer detecção pelos tiles
        RaycastHit hit;
        bool haveHit = Physics.Raycast(pos.position, pos.forward, out hit, range);
        if (haveHit && Turns.enemyTurn)
        {
            if (hit.collider.CompareTag("Player"))
            {
                //MORTE MELHORAR ESSA PORA
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (hit.collider.CompareTag("Escudeiro"))
            {
                currentCd--;
                if (currentCd < 0)
                {
                    currentCd = cooldown;
                    Escudeiro.vida--;
                }

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
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(pos.position, pos.forward * range);
        }

    }
}
