using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class Reset : MonoBehaviour
{
    public bool resetMechanic = true;

    [ShowIf("resetMechanic", true)]
    [TableList(ShowIndexLabels = true)]
    public List<GameObject> spawns;

    [ShowIf("resetMechanic")]
    [PreviewField(40, ObjectFieldAlignment.Left)]
    [ListDrawerSettings(NumberOfItemsPerPage = 3, ShowIndexLabels = true)]
    public List<GameObject> deactive;

    [ShowIfGroup("resetMechanic")]
    [BoxGroup("resetMechanic/Feedback")]
    public float duration;

    [BoxGroup("resetMechanic/Feedback")]
    public Vector3 target;

    [BoxGroup("resetMechanic/Feedback")]
    public Ease ease;

    [BoxGroup("resetMechanic/Feedback")]
    public GameObject smile;
    private TileManager _tileManager;
    private Vector3 _endtarget;

    private void Start()
    {
        _endtarget = smile.transform.position;
        _tileManager = FindObjectOfType<TileManager>();
        resetMechanic = true;
        while (spawns.Count > deactive.Count)
        {
            deactive.Add(null);
        }
    }

    public void SpawnObjects()
    {

        for (int i = 0; i < spawns.Count; i++)
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
        smile.transform.DOMove(_endtarget, duration).SetEase(ease);
    }

}
