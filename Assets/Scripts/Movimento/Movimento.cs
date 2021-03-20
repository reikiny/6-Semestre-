using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimento : MonoBehaviour
{
    public bool cima;
    public bool baixo;
    public bool esquerda;
    public bool direita;
    Vector3 target;
    public float step;

   
    private void Update()
    {
        Rayteste();
        if (Input.GetMouseButtonDown(0))
        {
            Mover();
            
        }      
    }
    void Rayteste()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1f) 
            || Physics.Raycast(transform.position, Vector3.back, out hit, 1f )
            || Physics.Raycast(transform.position, Vector3.left, out hit, 1f ) 
            || Physics.Raycast(transform.position, Vector3.right, out hit, 1f))
        {
            if (hit.collider.tag == "Andar")
            {
                hit.collider.tag = "Click";
            }
            else
            {
               
            }
           Debug.DrawRay(transform.position, Vector3.forward * hit.distance, Color.yellow);
           Debug.DrawRay(transform.position, Vector3.back * hit.distance, Color.yellow);
           Debug.DrawRay(transform.position, Vector3.left * hit.distance, Color.yellow);
           Debug.DrawRay(transform.position, Vector3.right * hit.distance, Color.yellow);
           
        }
        else
        {
            
        }
    }

    void Mover()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Click")
        {
            
            target = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}
