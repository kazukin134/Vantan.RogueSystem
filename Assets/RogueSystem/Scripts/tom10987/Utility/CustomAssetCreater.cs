
#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public static class CustomAssetCreater
{
  public static void CreateAsset(this System.Type type)
  {
    var asset = ScriptableObject.CreateInstance(type);
    ProjectWindowUtil.CreateAsset(asset, "NewAsset.asset");
  }
}

#endif
