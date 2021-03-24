using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGround : MonoBehaviour
{
    public Tile tile;
    public int nmr;
    public Directions[] directions;
    private void Start()
    {
        tile.esquerda = directions[nmr].esquerda;
        tile.direita = directions[nmr].direita;
        tile.baixo = directions[nmr].baixo;
        tile.cima = directions[nmr].cima;
    }
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
