using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Transform target;
    public float step;

    private void Update()
    {
        Mover();
    }
   
    void Mover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Andar")
            {
                Vector3 end = hit.point;
                target = hit.transform;
                transform.position = Vector3.MoveTowards(transform.position, target.position, 2f);
            }
            Debug.DrawLine(ray.origin, hit.point);
        }
    }
}
