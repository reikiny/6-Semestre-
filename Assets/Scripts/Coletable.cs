using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletable : MonoBehaviour
{
    public GameObject[] images;

    public bool[] active;
    public string[] names;

    private void OnEnable()
    {
        for (int i = 0; i < images.Length; i++)
        {
            active[i] = PlayerPrefs.GetInt(names[i]) == 1 ? true : false;
            images[i].SetActive(active[i]);
        }
    }

    public void Activate()
    {
        // active[0] = PlayerPrefs.GetInt("Image1") == 1 ? true : false;
        // active[1] = PlayerPrefs.GetInt("Image2") == 1 ? true : false;
        // active[2] = PlayerPrefs.GetInt("Image3") == 1 ? true : false;
        // active[3] = PlayerPrefs.GetInt("Image4") == 1 ? true : false;
        // active[4] = PlayerPrefs.GetInt("Image5") == 1 ? true : false;
        // active[5] = PlayerPrefs.GetInt("Image6") == 1 ? true : false;
        // active[6] = PlayerPrefs.GetInt("Image7") == 1 ? true : false;

        for (int i = 0; i < images.Length; i++)
        {
            active[i] = PlayerPrefs.GetInt(names[i]) == 1 ? true : false;
            images[i].SetActive(active[i]);
        }
    }

    public void Save()
    {
        for (int i = 0; i < images.Length; i++)
        {

            PlayerPrefs.SetInt(names[i], active[i] ? 1 : 0);
        }

        print(" 1 " + PlayerPrefs.GetInt("Image1") + " 2: " +
        PlayerPrefs.GetInt("Image2") + " 3: " +
        PlayerPrefs.GetInt("Image3") + " 4: " +
        PlayerPrefs.GetInt("Image4") + " 5: " +
        PlayerPrefs.GetInt("Image5") + " 6: " +
        PlayerPrefs.GetInt("Image6") + " 7: " +
        PlayerPrefs.GetInt("Image7"));
    }
}
