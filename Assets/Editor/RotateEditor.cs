using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(RotateGround))]
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
        if (GUI.changed)
        {
            EditorUtility.SetDirty(rotate);
            EditorSceneManager.MarkSceneDirty(rotate.gameObject.scene);
        }
    }
}
