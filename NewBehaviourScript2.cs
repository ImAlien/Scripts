using UnityEngine;
using UnityEditor;

public class CustomSceneViewRotation : EditorWindow
{
    private Vector3 rotationEulerAngles = Vector3.zero;
    private bool controlRotation = false; // 用于控制旋转限制的开关

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
            // 禁用鼠标右键旋转视角
            Event e = Event.current;
            if (e.button == 1 && e.type == EventType.MouseDrag)
            {
                e.Use(); // 阻止右键拖动事件
            }

            // 应用自定义的旋转角度
            sceneView.rotation = Quaternion.Euler(rotationEulerAngles);
            sceneView.Repaint();
        }
    }

    private void OnGUI()
    {
        controlRotation = EditorGUILayout.Toggle("固定视角", controlRotation);
        // Toggle 开关控制
        
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
            EditorGUILayout.HelpBox("固定视角已禁用", MessageType.Info);
        }
    }
}
