using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(MiniTile))]

public class RotateUI : Editor
{
   public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MiniTile rotate = (MiniTile)target;
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
