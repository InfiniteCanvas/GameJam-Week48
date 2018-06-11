using UnityEditor;
using UnityEngine;

namespace ScriptableObjectsFramework.FSM
{
    [CustomPropertyDrawer(typeof(State))]
    public class FSMStateDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }

}