using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float range;
    public Transform pos;
    public float cooldown;
    [HideInInspector]
    public float currentCd;
    public Image cdImage;

    private void Start()
    {
        currentCd = cooldown;
    }
    private void Update()
    {
        Bater();
        UI();
    }

    public void Bater()
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
                currentCd++;

                if (currentCd > cooldown)
                {
                    currentCd = 0;
                    Jons.vida--;

                }

            }
        }
    }

    public void UI()
    {
        cdImage.fillAmount = currentCd / cooldown;
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
