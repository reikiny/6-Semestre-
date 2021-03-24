using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TileManager tileManager;
    public float step;
    bool walk;
    [HideInInspector]
    public Tile tileClicked;
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
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Mathf.Infinity, layer) && hit.collider.CompareTag("Tile")
        && !Escudeiro.ativo && Turns.playerTurn && !MiniGame.miniOpen)
        {
            tileClicked = hit.collider.gameObject.GetComponent<Tile>();

            if (tileClicked.clicavel)
            {
                Acoes();
            }
            //Matar Inimigo, precisa fazer certinho depois
            if (tileClicked.agentes == Agentes.Inimigo && Vector3.Distance(transform.position, tileClicked.objeto.transform.position) <= step * 1.5f)
            {
                tileClicked.objeto.SetActive(false);

                Acoes();


            }
            if (tileClicked.agentes == Agentes.Bau && Vector3.Distance(transform.position, tileClicked.objeto.transform.position) <= step * 1.5f)
            {

                Acoes();

            }
            //print(Vector3.Distance(transform.position, tileClicked.objeto.transform.position));
            //Debug.DrawLine(ray.origin, hit.point);
            //Debug.Log(hit.collider.gameObject);
        }

        if (walk)
        {
            target = new Vector3(tileClicked.transform.position.x, transform.position.y, tileClicked.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);

        }
        if (Turns.playerTurn) walk = false;

    }

    void Acoes()
    {
        Turns.playerTurn = false;
        walk = true;
        Vector3 point = tileClicked.transform.position;
        point.y = transform.position.y;
        transform.LookAt(point);
    }

}
