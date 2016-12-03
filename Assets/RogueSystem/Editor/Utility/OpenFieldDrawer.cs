
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(OpenFieldAttribute))]
public class OpenFieldDrawer : PropertyDrawer
{
  OpenFieldAttribute openAttribute
  {
    get { return attribute as OpenFieldAttribute; }
  }

  public override void OnGUI(Rect position,
                             SerializedProperty property,
                             GUIContent label)
  {
    var field = property.FindPropertyRelative(openAttribute.fieldName);
    EditorGUI.PropertyField(position, field, label);
  }
}
