using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ArcherAuto : ArcherBase
{
    protected override void Bater()
    {
        //fazer detecção pelos tiles
        RaycastHit hit;
        bool haveHit = Physics.Raycast(pos.position, pos.forward, out hit, range);
        if (Turns.enemyTurn)
        {
            currentCd++;

            if (currentCd > cooldown)
            {
                currentCd = 0;

                if (haveHit)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        //MORTE MELHORAR ESSA PORA
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                    else if (hit.collider.CompareTag("Escudeiro"))
                    {
                        Jons.vida--;
                    }
                    else if (hit.collider.CompareTag("Enemy"))
                    {
                        Destroy(hit.collider.gameObject);
                        
                    }
                }
            }
        }
    }

    protected override void Aim()
    {
        RaycastHit hit;
        _lineRenderer.SetPosition(0, pos.position);
        if (Physics.Raycast(pos.position, pos.forward, out hit, range))
        {
            if (hit.collider) _lineRenderer.SetPosition(1, transform.forward * hit.distance + pos.position);
        }
        else _lineRenderer.SetPosition(1, transform.forward * range + pos.position);

    }
}
