using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimento : MonoBehaviour
{
    public bool cima;
    public bool baixo;
    public bool esquerda;
    public bool direita;
    //Vector3 target;
    //public float step;
    public float distace;

   
    private void Update()
    {
        Rayteste();
        //if (Input.GetMouseButtonDown(0))
        //{
            //Mover();
            
        //}      
    }
    void Rayteste()
    {
        RaycastHit hit;
        if (cima && Physics.Raycast(transform.position, Vector3.forward, out hit, distace))
        {
            Debug.DrawRay(transform.position, Vector3.forward * hit.distance, Color.yellow);
        }
        if (baixo && Physics.Raycast(transform.position, Vector3.back, out hit, distace))
        {
            Debug.DrawRay(transform.position, Vector3.back * hit.distance, Color.yellow);
        }
        if (esquerda && Physics.Raycast(transform.position, Vector3.left, out hit, distace))
        {
            Debug.DrawRay(transform.position, Vector3.left * hit.distance, Color.yellow);
        }
        if (direita && Physics.Raycast(transform.position, Vector3.right, out hit, distace))
        {
            Debug.DrawRay(transform.position, Vector3.right * hit.distance, Color.yellow);
        }  
    }

    //void Mover()
    //{
    //    RaycastHit hit;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Click")
    //    {

    //        target = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
    //        transform.position = Vector3.MoveTowards(transform.position, target, step);
    //    }
    //}
}
