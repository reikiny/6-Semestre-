using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TileManager tileManager;
    public float step;

    int layer;
    Vector3 target;

    private void Start()
    {
        layer = LayerMask.GetMask("Tile");
    }
    private void Update()
    {
        Mover();
    }
    void Mover()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit,layer) && hit.collider.CompareTag("Tile"))
        {
            if (hit.collider.gameObject.GetComponent<Tile>().clicavel && Turns.playerTurn)
            {
                Turns.playerTurn = false;
                target = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, step);
            }

            if (hit.collider.gameObject.GetComponent<Tile>().agentes == Agentes.Inimigo && Turns.playerTurn)
            {
                Turns.playerTurn = false;
                target = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, step);
            }
            
            Debug.DrawLine(ray.origin, hit.point);
        }
    }
}
