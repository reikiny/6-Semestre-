using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jons : MonoBehaviour
{
    public static int vida;
    public GameObject[] vidas;
    void Start()
    {
        vida = 3;
    }

    void Update()
    {

        for (int i = 0; i < vidas.Length; i++)
        {
            if (i > vida - 1)
                vidas[i].SetActive(false);
        }

        if (vida <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
