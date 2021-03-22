using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Agentes { Player, Inimigo, Escudeiro, Vazio }
public class Tile : MonoBehaviour
{
    public Agentes agentes;

    public bool cima;
    public bool baixo;
    public bool direita;
    public bool esquerda;

    public bool clicavel;
    //remover depois
    [HideInInspector]
    public GameObject inimigo;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agentes = Agentes.Player;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            agentes = Agentes.Inimigo;
            inimigo = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Escudeiro"))
        {
            agentes = Agentes.Escudeiro;
        }
        else
        {
            agentes = Agentes.Vazio;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        agentes = Agentes.Vazio;


    }
}
