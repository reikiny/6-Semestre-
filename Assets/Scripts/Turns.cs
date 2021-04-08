using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    public float turnCount;
    public float waitTime;
    public static bool playerTurn = true;
    public static bool enemyTurn;
    public Text turnDisplay;
    bool control = true;

    private void Start()
    {
        turnDisplay.text = turnCount.ToString();
    }

    private void Update()
    {
        //Usando o control pra nao iniciar a coroutine mais de uma vez. O turn count é caso quisermos contar quantos turnos ele passou
        if (!playerTurn && control)
        {
            control = false;
            StartCoroutine(WaitEnemyTurn());
            turnCount++;
            turnDisplay.text = turnCount.ToString();
        }
    }

    IEnumerator WaitEnemyTurn()
    {
        //esperar um tempo pra IA agir
        yield return new WaitForSeconds(waitTime);
        enemyTurn = true;
        //espera 1 frame e depois deixa acessivel pro player fazer o movimento dele 
        yield return 0;
        enemyTurn = false;
        playerTurn = true;
        control = true;
    }
}
