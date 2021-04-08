using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class ArcherRotate : ArcherBase
{
    [Range(2, 4)]
    public int rotateSides;
    public bool clockWise;
    private int _index;

    protected override void Init()
    {
        base.Init();
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
    public void ChangeSide()
    {
        if (!clockWise)
        {
            _index++;
            if (_index >= rotateSides)
            {
                _index = 0;
            }
        }
        else
        {
            _index--;
            if (_index <= -rotateSides)
            {
                _index = 0;
            }
        }

        transform.rotation = Quaternion.Euler(0f, 90f * _index, 0f);
        Bater();

    }
}
