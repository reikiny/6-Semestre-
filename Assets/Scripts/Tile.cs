using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Agentes { Player, Inimigo, Escudeiro, Vazio, Bau, End, Obstaculo }
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
