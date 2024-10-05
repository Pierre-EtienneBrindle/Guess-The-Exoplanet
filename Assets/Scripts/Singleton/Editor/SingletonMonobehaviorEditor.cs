using UnityEditor;

namespace SingletonBehavior.Editors
{
    [CustomEditor(typeof(SingletonMonobehavior<>), true)]
    public class SingletonMonobehaviorEditor : Editor
    {
        public override void OnInspectorGUI ()
        {
            EditorGUILayout.LabelField("If a singleton is persistant, it won't be destroyed when loading a new scene", EditorStyles.wordWrappedLabel);
            base.OnInspectorGUI();
        }
    }
}