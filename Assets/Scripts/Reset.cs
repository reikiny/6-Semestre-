using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Reset : MonoBehaviour
{
    public bool resetMechanic = true;
    public GameObject[] spawns;
    public GameObject[] deactive;
    TileManager tileManager;
    [Header("Feedback")]
    public float duration;
    public Vector3 target;
    Vector3 endtarget;
    public Ease ease;
    public GameObject smile;

    private void Start()
    {
        endtarget = smile.transform.position;
        tileManager = FindObjectOfType<TileManager>();
        resetMechanic = true;
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            deactive[i].SetActive(false);
            spawns[i].SetActive(true);
        }
        
        StartCoroutine(SmileAnimation());

    }

    IEnumerator SmileAnimation()
    {
        smile.transform.DOMove(target, duration).SetEase(ease);
        yield return new WaitForSeconds(duration * 2);
        smile.transform.DOMove(endtarget, duration).SetEase(ease);
    }

}
