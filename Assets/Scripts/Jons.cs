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

    // Update is called once per frame
    void Update()
    {
        if (vida < 3)
            vidas[vida].SetActive(false);

        if (vida == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
