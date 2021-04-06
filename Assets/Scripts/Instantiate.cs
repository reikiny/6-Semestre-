using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Instantiate : MonoBehaviour
{
    [PropertyOrder(-1)]
    [HideIf("_toggle")]
    public int quantity;

    [PropertyOrder(-1)]
    [ShowIf("_toggle2")]
    public int quantity2;

    [FoldoutGroup("Specifications")]
    [PropertyOrder(2)]
    public List<GameObject> waypoints;

    [PropertyOrder(3)]
    [FoldoutGroup("Specifications")]
    public GameObject prefab;

    private bool _toggle;
    private bool _toggle2;
    private bool _hide;
    private int _index;
    private int _index2;

    private void Start()
    {
        transform.parent = null;
    }

    [PropertyOrder(1)]
    [HideIf("_toggle")]
    [Button(ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1f)]
    [ButtonGroup]
    private void CreateFront()
    {
        _toggle = !_toggle;
        _toggle2 = true;
        for (int i = 0; i < quantity; i++)
        {
            Vector3 pos = new Vector3(transform.position.x + i * 2, transform.position.y, transform.position.z);
            GameObject go = Instantiate(prefab, pos, Quaternion.identity);
            go.name = i.ToString();
            go.transform.parent = gameObject.transform;
            waypoints.Add(go);
        }
    }

    [PropertyOrder(1)]
    [ShowIf("_toggle2")]
    [Button(ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1f)]
    [ButtonGroup]
    private void CreateSide()
    {
        _hide = !_hide;
        _toggle2 = false;
        for (int i = 0; i < quantity2; i++)
        {
            Transform wayPosition = waypoints[quantity - 1].transform;
            Vector3 pos = new Vector3(wayPosition.position.x + (i + 1) * 2, wayPosition.position.y, wayPosition.position.z);
            GameObject go = Instantiate(prefab, pos, Quaternion.identity);
            go.name = (quantity + i).ToString();
            go.transform.parent = wayPosition;
            waypoints.Add(go);
        }
    }

    [PropertyOrder(1)]
    [ShowIf("_toggle")]
    [Button(ButtonSizes.Large), GUIColor(1f, 0.2f, 0.2f)]
    [ButtonGroup]
    private void Clear()
    {
        _toggle = !_toggle;
        _hide = !_hide;

        for (int i = 0; i < waypoints.Count; i++)
        {
            if (waypoints != null)
                GameObject.DestroyImmediate(waypoints[i]);
        }
        waypoints.Clear();

    }

    [PropertyOrder(1)]
    [Button(ButtonSizes.Medium)]
    [GUIColor(0.6f, 1f, 0.6f)]
    [ShowIf("_toggle")]
    [ButtonGroup("Rotate")]
    public void ChangeSide()
    {
        _index++;
        if (_index == 4)
        {
            _index = 0;
        }
        transform.rotation = Quaternion.Euler(0f, 90f * _index, 0f);

    }

    [PropertyOrder(1)]
    [Button(ButtonSizes.Medium)]
    [GUIColor(0.2f, 1f, 0.2f)]
    [ButtonGroup("Rotate")]
    [ShowIf("_hide")]
    public void ChangeSide2()
    {
        _index2++;
        if (_index2 == 4)
        {
            _index2 = 0;
        }
        waypoints[quantity - 1].transform.rotation = Quaternion.Euler(0f, 90f * _index2, 0f);

    }

}
