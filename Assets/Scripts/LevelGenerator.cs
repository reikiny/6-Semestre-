using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LevelGenerator : MonoBehaviour
{
    [PreviewField(150, ObjectFieldAlignment.Center)]
    [HideLabel]
    [TabGroup("Map")]
    public Texture2D map;

    [TableList]
    [FoldoutGroup("Specifications", expanded: false)]
    [PropertySpace(SpaceBefore = 10, SpaceAfter = 10)]
    public ColorToPrefab[] colorMappings;

    [FoldoutGroup("Specifications", expanded: false)]
    [LabelWidth(100)]
    [Range(1, 3)]
    public float multiplicador;

    private List<GameObject> _stored= new List<GameObject>();
    private bool _toggle;

    [TabGroup("Map")]
    [Button(ButtonSizes.Large)]
    [GUIColor(0.6f, 1f, 0.6f)]
    [HideIf("_toggle")]
    [PropertySpace(SpaceBefore = 10, SpaceAfter = 0)]
    public void GenerateLevel()
    {
        _toggle = !_toggle;
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);

            }
        }
    }


    public void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            //pixel é transparente. FAZ NADA

            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {

            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x * multiplicador, 0, y * multiplicador);
                GameObject go = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                _stored.Add(go);
            }
        }
    }


    [ShowIf("_toggle")]
    [Button(ButtonSizes.Large),GUIColor(1f,0.2f,0.2f)]
    [TabGroup("Map")]
    private void Clear()
    {
        _toggle = !_toggle;
        for (int i = 0; i < _stored.Count; i++)
        {
            GameObject.DestroyImmediate(_stored[i]);
        }
            _stored.Clear();
    }
}
