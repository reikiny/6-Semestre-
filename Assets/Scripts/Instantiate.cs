using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Instantiate : MonoBehaviour
{
    [PropertyOrder(-1)]
    public int quantity;

    [FoldoutGroup("Specifications")]
    [PropertyOrder(2)]
    public List<GameObject> waypoints;

    [PropertyOrder(3)]
    [FoldoutGroup("Specifications")]
    public GameObject prefab;

    private bool _toggle;

    private void Start()
    {
        transform.parent = null;
    }

    [PropertyOrder(1)]
    [HideIf("_toggle")]
    [Button(ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1f)]
    private void Create()
    {
        _toggle = !_toggle;
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
    [ShowIf("_toggle")]
    [Button(ButtonSizes.Large), GUIColor(1f, 0.2f, 0.2f)]
    private void Clear()
    {
        _toggle = !_toggle;
        for (int i = 0; i < waypoints.Count; i++)
        {
            GameObject.DestroyImmediate(waypoints[i]);
        }
        waypoints.Clear();
    }

}
