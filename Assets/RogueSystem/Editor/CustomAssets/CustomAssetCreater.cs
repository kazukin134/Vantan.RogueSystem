
using UnityEditor;
using UnityEngine;

public static class CustomAssetCreater
{
  [MenuItem("Custom Assets/Create Input Axis Manager")]
  static void Create_InputAxisManager()
  {
    CreateAsset(typeof(InputAxisManager));
  }

  static void CreateAsset(System.Type type)
  {
    var asset = ScriptableObject.CreateInstance(type);
    ProjectWindowUtil.CreateAsset(asset, "NewAsset.asset");
  }
}
