using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public MiniTile[] miniTiles;
    public GameObject display;
    public bool won;

    [Header("Colecionavel")]
    public GameObject reward;
    public int nmbr;
    public Coletable coletable;

    [Header("Feedback de Tempo")]
    public Slider sliderTime;
    public Image timeImage;
    public float totalTime;
    float time;

    public static bool miniOpen;
    bool control;

    private void Start()
    {
        if (PlayerPrefs.GetInt(coletable.names[nmbr]) == 1 ? true : false)
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        //PlayerPrefs.SetInt("Image", 0);
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

        timeImage.fillAmount = time / totalTime;
        sliderTime.value = time / totalTime;


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
        reward.gameObject.SetActive(true);
        coletable.active[nmbr] = true;
        coletable.Save();
        print("coletable: " + coletable.active[nmbr]);
        yield return new WaitForSeconds(.5f);
        coletable.Activate();
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        miniOpen = false;
    }



}
