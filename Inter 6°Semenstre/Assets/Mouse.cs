using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject path;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Vector3 end = hit.point;
            path.transform.position = end;
        }
    }
    //void OnMouseOver()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, 1))
    //    {
    //        Debug.DrawLine(ray.origin, hit.point);
    //        Vector3 end = transform.position + ray.direction * 1000;
    //        transform.position = end;
    //    }
    //}
    //void OnMouseExit()
    //{
    //    //The mouse is no longer hovering over the GameObject so output this message each frame
    //    Debug.Log("Mouse is no longer on GameObject.");
    //    path.transform.position = new Vector3(path.transform.position.x, path.transform.position.y, path.transform.position.z);
    //}
}
