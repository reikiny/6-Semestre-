using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RotateGround)), CanEditMultipleObjects]
public class RotateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RotateGround rotate = (RotateGround)target;
        if (GUILayout.Button("RotateTile"))
        {
            rotate.ChangeSide();
        }
    }
}
