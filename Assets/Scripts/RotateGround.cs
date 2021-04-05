using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Tile))]
public class RotateGround : MonoBehaviour
{
    [FoldoutGroup("Specifications", expanded: false)]
    public Tile tile;

    [FoldoutGroup("Specifications")]
    public int nmr;

    [TableList(ShowIndexLabels = true)]
    public Directions[] directions;
    private void Start()
    {
        tile.esquerda = directions[nmr].esquerda;
        tile.direita = directions[nmr].direita;
        tile.baixo = directions[nmr].baixo;
        tile.cima = directions[nmr].cima;
    }

    [Button(ButtonSizes.Medium)]
    [GUIColor(0.6f, 1f, 0.6f)]
    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
    public void ChangeSide()
    {
        nmr++;
        if (nmr == directions.Length)
        {
            nmr = 0;
        }
        tile.esquerda = directions[nmr].esquerda;
        tile.direita = directions[nmr].direita;
        tile.baixo = directions[nmr].baixo;
        tile.cima = directions[nmr].cima;
        transform.rotation = Quaternion.Euler(0f, 90f * nmr, 0f);

    }
}

[System.Serializable]
public class Directions
{
    public bool cima;
    public bool baixo;
    public bool direita;
    public bool esquerda;
}
