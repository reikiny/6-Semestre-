using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class ArcherRotate : ArcherBase
{
    [PropertyOrder(1)]
    public bool clockWise;
    private int _index;
    private List<int> angles = new List<int>();
    private Tile underTile;
    protected override void Init()
    {
        base.Init();
        GetTile();
        ChangeSide();
    }
    protected override void Inherited()
    {
        base.Inherited();
        if (Turns.enemyTurn)
            ChangeSide();
    }

    [Button(ButtonSizes.Medium)]
    [GUIColor(0.6f, 1f, 0.6f)]
    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
    [PropertyOrder(1)]
    public void ChangeSide()
    {
        if (underTile == null) GetTile();
        else
        {
            transform.rotation = Quaternion.Euler(0f, angles[_index], 0f);

            _index++;
            if (_index == angles.Count)
            {
                _index = 0;
            }

            Bater();
        }


    }

    [Button(ButtonSizes.Large), GUIColor(1f, 0.2f, 0.2f)]
    [ButtonGroup]
    [ShowIf("underTile")]
    [PropertyOrder(1)]
    public void Clear()
    {
        underTile = null;
        angles.Clear();
        _index = 0;
    }

    private void GetTile()
    {
        RaycastHit hit;
        bool haveHit = Physics.Raycast(pos.position, -pos.up, out hit, range, ~_layerMask);

        if (haveHit && hit.collider.CompareTag("Tile"))
        {
            underTile = hit.collider.GetComponent<Tile>();

            if (angles.Count == 0)
                AddAngle();
            else
            {
                foreach (int ang in angles)
                {
                    if (ang != 0 && ang != 180 && ang != 90 && ang != 270)
                    {
                        AddAngle();
                    }
                }
            }


        }
    }

    private void AddAngle()
    {
        if (clockWise)
        {
            if (underTile.cima) angles.Add(0);
            if (underTile.direita) angles.Add(90);
            if (underTile.baixo) angles.Add(180);
            if (underTile.esquerda) angles.Add(270);
        }
        else
        {
            if (underTile.esquerda) angles.Add(270);
            if (underTile.baixo) angles.Add(180);
            if (underTile.direita) angles.Add(90);
            if (underTile.cima) angles.Add(0);
        }
    }
}
