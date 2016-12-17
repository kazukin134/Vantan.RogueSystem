
using UnityEngine;

[DisallowMultipleComponent]
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
  protected static T _instance = null;

  public static bool exists { get { return _instance != null; } }

  protected virtual void Awake()
  {
    if (_instance == null) { _instance = this as T; }
    if (_instance != this) { DestroyImmediate(this); }
  }

  protected virtual void OnDestroy()
  {
    if (_instance == this) { _instance = null; }
  }
}
