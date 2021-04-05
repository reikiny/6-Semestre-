using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum Agentes { Player, Inimigo, Escudeiro, Vazio, Bau, End, Obstaculo }
public class Tile : MonoBehaviour
{
    [BoxGroup("Directions")]
    public bool cima;

    [BoxGroup("Directions")]
    public bool baixo;

    [BoxGroup("Directions")]
    public bool direita;

    [BoxGroup("Directions")]
    public bool esquerda;

    [BoxGroup("Agentes")]
    [HideLabel]
    public Agentes agentes;

    [BoxGroup("Clickable")]
    public bool clicavel;



    //remover depois
    [HideInInspector]
    public GameObject objeto;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agentes = Agentes.Player;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            agentes = Agentes.Inimigo;
            objeto = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Escudeiro"))
        {
            agentes = Agentes.Escudeiro;
        }
        else if (other.gameObject.CompareTag("Bau"))
        {
            agentes = Agentes.Bau;
            objeto = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Obstaculo"))
        {
            agentes = Agentes.Obstaculo;
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
