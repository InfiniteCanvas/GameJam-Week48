using UnityEditor;
using UnityEngine;

namespace ScriptableObjectsFramework.Utility
{
    [CustomPropertyDrawer(typeof(StringStatePair))]
    public class StringStatePairDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var name = property.FindPropertyRelative("Name");
            var so = property.FindPropertyRelative("ScriptableObject");

            int width = 40;

            var labelRect = new Rect(position.x, position.y, width, position.height);
            var nameRect = new Rect(position.x + width, position.y, EditorGUIUtility.labelWidth - width, position.height);
            var soRect = new Rect(position.x + EditorGUIUtility.labelWidth, position.y, position.width - EditorGUIUtility.labelWidth, position.height);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            EditorGUI.LabelField(labelRect, "Name");
            EditorGUI.PropertyField(nameRect, name, GUIContent.none);
            EditorGUI.PropertyField(soRect, so, GUIContent.none);

            EditorGUI.indentLevel = indent;
        }
    }
}