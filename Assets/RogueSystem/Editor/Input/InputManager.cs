
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class InputManager
{
  static readonly string FilePath = "ProjectSettings/InputManager.asset";
  static readonly string Property = "m_Axes";
  static readonly string AxisName = "m_Name";

  static SerializedObject _inputManager = null;
  static SerializedProperty _axes = null;

  [InitializeOnLoadMethod]
  [MenuItem("Custom Assets/Load Input Manager", priority = 11)]
  static void LoadInputManager()
  {
    var assets = AssetDatabase.LoadAllAssetsAtPath(FilePath);
    _inputManager = new SerializedObject(assets[0]);
    _axes = _inputManager.FindProperty(Property);
  }

  static IEnumerable<string> GetAxisNames()
  {
    for (int i = 0, length = _axes.arraySize; i < length; ++i)
    {
      var property = _axes.GetArrayElementAtIndex(i);
      yield return property.FindPropertyRelative(AxisName).stringValue;
    }
  }

  public static string[] axisNames
  {
    get { return GetAxisNames().ToArray(); }
  }
}
