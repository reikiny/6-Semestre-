using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArcherBase : Enemy
{
    protected LineRenderer _lineRenderer;

    protected override void Init()
    {
        base.Init();
        _lineRenderer = GetComponent<LineRenderer>();

    }

    protected override void Inherited()
    {
        base.Inherited();
        Aim();
    }
    protected virtual void Aim()
    {
        RaycastHit hit;
        _lineRenderer.SetPosition(0, pos.position);
        if (Physics.Raycast(pos.position, pos.forward, out hit, range, ~_layerMask))
        {
            if (hit.collider) _lineRenderer.SetPosition(1, transform.forward * hit.distance + pos.position);
        }
        else _lineRenderer.SetPosition(1, transform.forward * range + pos.position);

    }

}
