using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimento))]
public class Personagem : MonoBehaviour
{
    Movimento movimento;
    private void Start()
    {
        movimento = GetComponent<Movimento>();
    }
}

