
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomPropertyDrawer(typeof(InputAxis.AxisIndexAttribute))]
public class AxisIndexDrawer : PropertyDrawer
{
  InputAxis.AxisIndexAttribute indexAttribute
  {
    get { return attribute as InputAxis.AxisIndexAttribute; }
  }

  public override void OnGUI(Rect position,
                             SerializedProperty property,
                             GUIContent label)
  {
    var names = InputManager.axisNames;
    if (IsEmptyField(property, position, ref names)) { return; }

    var currentName = property.stringValue;
    indexAttribute.selected = GetIndex(currentName, ref names);

    var index = PopupField(position, label.text, ref names);
    if (!GUI.changed) { return; }

    indexAttribute.selected = index;
    property.stringValue = names[index];
  }

  bool IsEmptyField(SerializedProperty property,
                    Rect position,
                    ref string[] names)
  {
    bool empty = (names.Length <= 0);
    if (empty)
    {
      string label = ObjectNames.NicifyVariableName(property.name);
      EditorGUI.LabelField(position, label, "not exist axis name.");
    }
    return empty;
  }

  int GetIndex(string name, ref string[] names)
  {
    for (int i = 0, length = names.Length; i < length; ++i)
    {
      if (names[i] == name) { return i; }
    }
    return 0;
  }

  int PopupField(Rect position, string label, ref string[] names)
  {
    var current = indexAttribute.selected;
    var indices = names.Select((name, index) => index).ToArray();
    return EditorGUI.IntPopup(position, label, current, names, indices);
  }
}
