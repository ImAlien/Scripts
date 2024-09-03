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

        // ��ȡ��ǰ��� Scene ��ͼ
        SceneView sceneView = SceneView.lastActiveSceneView;

        if (sceneView != null)
        {
            // ��ȡ Scene ��ͼ�����λ�ú���ת��Ϣ
            Vector3 position = sceneView.camera.transform.position;
            Vector3 rotation = sceneView.camera.transform.rotation.eulerAngles;

            EditorGUILayout.LabelField("Position", position.ToString("F2"));
            EditorGUILayout.LabelField("Rotation", rotation.ToString("F2"));
        }
        else
        {
            EditorGUILayout.LabelField("No active Scene View found.");
        }

        // ˢ�°�ť
        if (GUILayout.Button("Refresh"))
        {
            Repaint();
        }
    }

    private void OnInspectorUpdate()
    {
        // �Զ�ˢ�´�������
        Repaint();
    }
}
