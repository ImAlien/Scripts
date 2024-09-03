using UnityEngine;
using UnityEditor;

public class SceneViewCameraInfo : EditorWindow
{
    [MenuItem("Tools/Scene View Camera Info")]
    public static void ShowWindow()
    {
        GetWindow<SceneViewCameraInfo>("Scene View Camera Info");
    }

    private void OnGUI()
    {
        GUILayout.Label("Scene View Camera Information", EditorStyles.boldLabel);

        // 获取当前活动的 Scene 视图
        SceneView sceneView = SceneView.lastActiveSceneView;

        if (sceneView != null)
        {
            // 获取 Scene 视图相机的位置和旋转信息
            Vector3 position = sceneView.camera.transform.position;
            Vector3 rotation = sceneView.camera.transform.rotation.eulerAngles;

            EditorGUILayout.LabelField("Position", position.ToString("F2"));
            EditorGUILayout.LabelField("Rotation", rotation.ToString("F2"));
        }
        else
        {
            EditorGUILayout.LabelField("No active Scene View found.");
        }

        // 刷新按钮
        if (GUILayout.Button("Refresh"))
        {
            Repaint();
        }
    }

    private void OnInspectorUpdate()
    {
        // 自动刷新窗口内容
        Repaint();
    }
}
