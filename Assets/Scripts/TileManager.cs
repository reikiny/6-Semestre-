using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile[] tile;

    GameObject[] temporarios = new GameObject[4];

    void Start()
    {

    }

    void Update()
    {
        Ray();
    }

    void Ray()
    {
        for (int i = 0; i < tile.Length; i++)
        {

            if (tile[i].agentes == Agentes.Player)
            {
                tile[i].clicavel = false;
                RaycastHit hit;

                if (tile[i].cima && Physics.Raycast(tile[i].transform.position, Vector3.forward, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    temporarios[0] = hit.collider.gameObject;
                    Debug.DrawRay(tile[i].transform.position, Vector3.forward * hit.distance, Color.yellow);
                }
                else if (!tile[i].cima)
                {
                    temporarios[0] = null;
                }

                if (tile[i].baixo && Physics.Raycast(tile[i].transform.position, Vector3.back, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    temporarios[1] = hit.collider.gameObject;
                    Debug.DrawRay(tile[i].transform.position, Vector3.back * hit.distance, Color.yellow);
                }
                else if (!tile[i].baixo)
                {
                    temporarios[1] = null;
                }

                if (tile[i].esquerda && Physics.Raycast(tile[i].transform.position, Vector3.left, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    temporarios[2] = hit.collider.gameObject;
                    Debug.DrawRay(tile[i].transform.position, Vector3.left * hit.distance, Color.yellow);
                }
                else if (!tile[i].esquerda)
                {
                    temporarios[2] = null;
                }

                if (tile[i].direita && Physics.Raycast(tile[i].transform.position, Vector3.right, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    temporarios[3] = hit.collider.gameObject;
                    Debug.DrawRay(tile[i].transform.position, Vector3.right * hit.distance, Color.yellow);
                }
                else if (!tile[i].direita)
                {
                    temporarios[3] = null;
                }

            }
            if (temporarios[0] != tile[i].gameObject && temporarios[1] != tile[i].gameObject
            && temporarios[2] != tile[i].gameObject && temporarios[3] != tile[i].gameObject)
            {
                tile[i].clicavel = false;
            }
            else tile[i].clicavel = true;

        }
    }
}
