
using UnityEngine;

public class InputAxisManager : ScriptableObject
{
  static InputAxisManager _entity = null;
  public static InputAxisManager entity { get { return _entity; } }

  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
  static void LoadAsset()
  {
    if (_entity != null) { return; }
    _entity = Resources.LoadAll<InputAxisManager>("")[0];
  }

  [SerializeField, OpenField("_name")]
  InputAxis _horizontal = null;
  public InputAxis horizontal { get { return _horizontal; } }

  [SerializeField, OpenField("_name")]
  InputAxis _vertical = null;
  public InputAxis vertical { get { return _vertical; } }

  [SerializeField, OpenField("_name")]
  InputAxis _action = null;
  public InputAxis action { get { return _action; } }
}
