using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudeiro : MonoBehaviour
{
    Vector3 target;
    public GameObject jons;

    bool ativo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (ativo)
        {
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Tile"))
            {
                if (hit.collider.gameObject.GetComponent<Tile>().agentes == Agentes.Vazio && Turns.playerTurn)
                {
                    Turns.playerTurn = false;

                    target = new Vector3(hit.transform.position.x, hit.transform.position.y + .5f, hit.transform.position.z);
                    Instantiate(jons, target, Quaternion.identity);
                    ativo = !ativo;
                }
            }
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Tile"))
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else if(hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

    public void Posicion()
    {
        ativo = !ativo;
    }
}
