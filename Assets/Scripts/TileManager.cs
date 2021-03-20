using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile[] tile; 

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
                        hit.collider.gameObject.GetComponent<Tile>().clicavel = true;
                        Debug.DrawRay(tile[i].transform.position, Vector3.forward * hit.distance, Color.yellow);
                    }
                   if (tile[i].baixo && Physics.Raycast(tile[i].transform.position, Vector3.back, out hit, 1f) && hit.collider.CompareTag("Tile"))
                    {
                        hit.collider.gameObject.GetComponent<Tile>().clicavel = true;
                        Debug.DrawRay(tile[i].transform.position, Vector3.back * hit.distance, Color.yellow);
                    }
                 if (tile[i].esquerda && Physics.Raycast(tile[i].transform.position, Vector3.left, out hit, 1f) && hit.collider.CompareTag("Tile"))
                    {
                        hit.collider.gameObject.GetComponent<Tile>().clicavel = true;
                        Debug.DrawRay(tile[i].transform.position, Vector3.left * hit.distance, Color.yellow);
                    }
                   if (tile[i].direita && Physics.Raycast(tile[i].transform.position, Vector3.right, out hit, 1f) && hit.collider.CompareTag("Tile"))
                    {
                        hit.collider.gameObject.GetComponent<Tile>().clicavel = true;
                        Debug.DrawRay(tile[i].transform.position, Vector3.right * hit.distance, Color.yellow);
                    }
               
            }
            if (tile[i].agentes == Agentes.Vazio || tile[i].agentes == Agentes.Escudeiro || tile[i].agentes == Agentes.Inimigo)
            {
                RaycastHit hit;

                if (tile[i].cima && Physics.Raycast(tile[i].transform.position, Vector3.forward, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    hit.collider.gameObject.GetComponent<Tile>().clicavel = false;
                    Debug.DrawRay(tile[i].transform.position, Vector3.forward * hit.distance, Color.yellow);
                }
                if (tile[i].baixo && Physics.Raycast(tile[i].transform.position, Vector3.back, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    hit.collider.gameObject.GetComponent<Tile>().clicavel = false;
                    Debug.DrawRay(tile[i].transform.position, Vector3.back * hit.distance, Color.yellow);
                }
                if (tile[i].esquerda && Physics.Raycast(tile[i].transform.position, Vector3.left, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    hit.collider.gameObject.GetComponent<Tile>().clicavel = false;
                    Debug.DrawRay(tile[i].transform.position, Vector3.left * hit.distance, Color.yellow);
                }
                if (tile[i].direita && Physics.Raycast(tile[i].transform.position, Vector3.right, out hit, 1f) && hit.collider.CompareTag("Tile"))
                {
                    hit.collider.gameObject.GetComponent<Tile>().clicavel = false;
                    Debug.DrawRay(tile[i].transform.position, Vector3.right * hit.distance, Color.yellow);
                }
            }
          
        }  
    }
}
