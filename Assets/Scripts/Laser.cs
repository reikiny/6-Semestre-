using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : Enemy
{
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        currentCd = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        lineRenderer.SetPosition(0, pos.position);
        if (Physics.Raycast(pos.position, pos.forward, out hit, range))
        {
            if (hit.collider) lineRenderer.SetPosition(1, transform.forward * hit.distance + pos.position);
        }
        else lineRenderer.SetPosition(1, transform.forward * range + pos.position);

        Bater();
        UI();
    }
}
