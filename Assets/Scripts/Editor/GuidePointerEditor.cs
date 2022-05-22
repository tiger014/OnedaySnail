using UnityEditor;

[CustomEditor(typeof(GuidePointer))]
public class LaserPointerEditor : Editor
{
    GuidePointer _target;
    SerializedProperty _rayTargetLayer;

    void OnEnable()
    {
        _target = (GuidePointer)target;
        _rayTargetLayer = serializedObject.FindProperty("_rayTargetLayer");
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.ObjectField("Editor", MonoScript.FromScriptableObject(this), typeof(LaserPointerEditor), false);
        EditorGUI.EndDisabledGroup();

        serializedObject.Update();
        base.OnInspectorGUI();
        _rayTargetLayer.intValue = EditorGUILayout.LayerField("Ray Target Layer", _rayTargetLayer.intValue);
        serializedObject.ApplyModifiedProperties();
    }
}
