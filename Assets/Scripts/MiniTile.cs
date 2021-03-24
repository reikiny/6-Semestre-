using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTile : MonoBehaviour
{

    public int nmr;
    public int nmrCerto;
    public int tamanho;
    public bool acerto;
    private void Update()
    {
        if (nmr == nmrCerto) acerto = true;
        else acerto = false;

        transform.rotation = Quaternion.Euler(0f, 0f, 90f * nmr);
    }
    public void ChangeSide()
    {
        nmr++;
        if (nmr == tamanho)
        {
            nmr = 0;
        }



    }
}

