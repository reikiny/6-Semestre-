using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class MiniGame : MonoBehaviour
{
    public MiniTile[] miniTiles;
    public GameObject display;
    public bool won;
    [Header("Colecionavel")]
    public Image image;
    [Header("Feedback de Tempo")]
    public Slider tempoSlider;
    public Image tempoImage;
    public float totalTime;
    float time;

    public static bool miniOpen;
    bool control;
    void Update()
    {

        for (int i = 0; i < miniTiles.Length; i++)
        {
            if (!miniTiles[i].acerto)
            {
                won = false;
                break;
            }
            else
            {
                won = true;
            }

        }
        if (won && !control)
        {
            StartCoroutine(ShowImage());
            control = true;

        }
        else if (!won) time += Time.deltaTime;

        if (time > totalTime)
        {
            miniOpen = false;
            gameObject.SetActive(false);
        }

        tempoImage.fillAmount = time / totalTime;
        tempoSlider.value = time / totalTime;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            display.SetActive(true);
            miniOpen = true;
        }
    }

    IEnumerator ShowImage()
    {
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        miniOpen = false;
    }

}
