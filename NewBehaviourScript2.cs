using UnityEngine;
using UnityEditor;

public class CustomSceneViewRotation : EditorWindow
{
    private Vector3 rotationEulerAngles = Vector3.zero;
    private bool controlRotation = false; // ���ڿ�����ת���ƵĿ���

    [MenuItem("Tools/Custom Scene View Rotation")]
    public static void ShowWindow()
    {
        GetWindow<CustomSceneViewRotation>("Scene View Rotation");
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        if (controlRotation)
        {
            // ��������Ҽ���ת�ӽ�
            Event e = Event.current;
            if (e.button == 1 && e.type == EventType.MouseDrag)
            {
                e.Use(); // ��ֹ�Ҽ��϶��¼�
            }

            // Ӧ���Զ������ת�Ƕ�
            sceneView.rotation = Quaternion.Euler(rotationEulerAngles);
            sceneView.Repaint();
        }
    }

    private void OnGUI()
    {
        controlRotation = EditorGUILayout.Toggle("�̶��ӽ�", controlRotation);
        // Toggle ���ؿ���
        
        if (controlRotation)
        {
            rotationEulerAngles = EditorGUILayout.Vector3Field("Rotation", rotationEulerAngles);

            if (GUILayout.Button("Apply Rotation"))
            {
                SceneView.lastActiveSceneView.rotation = Quaternion.Euler(rotationEulerAngles);
                SceneView.lastActiveSceneView.Repaint();
            }
        }
        else
        {
            EditorGUILayout.HelpBox("�̶��ӽ��ѽ���", MessageType.Info);
        }
    }
}
