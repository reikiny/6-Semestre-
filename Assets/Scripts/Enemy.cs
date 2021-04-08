using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Sirenix.OdinInspector;
public class Enemy : MonoBehaviour
{
    [VerticalGroup("Split", 0.5f)]
    [BoxGroup("Split/Attack")]
    public float range;

    [BoxGroup("Split/Attack")]
    [ChildGameObjectsOnly]
    public Transform pos;

    [BoxGroup("Split/Feedback")]
    public float cooldown;

    [BoxGroup("Split/Feedback")]
    [PreviewField(30, ObjectFieldAlignment.Left)]
    [ChildGameObjectsOnly]
    public Image cdImage;

    [HideInInspector]
    public float currentCd;
    protected GameObject[] _enemies;
    protected LayerMask _layerMask = (1 << 9);

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        currentCd = cooldown;
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        Inherited();
    }

    protected virtual void Inherited()
    {
        Bater();
        UI();
    }

    protected virtual void Bater()
    {
        //fazer detecção pelos tiles
        RaycastHit hit;
        bool haveHit = Physics.Raycast(pos.position, pos.forward, out hit, range, ~_layerMask);
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

        bool isHit = Physics.Raycast(pos.position, pos.forward, out hit, range, ~_layerMask);
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
