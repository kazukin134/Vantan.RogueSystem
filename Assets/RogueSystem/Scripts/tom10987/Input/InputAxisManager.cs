
using UnityEngine;

public class InputAxisManager : ScriptableObject
{
#if UNITY_EDITOR
  [UnityEditor.MenuItem("Custom Assets/Create Input Axis Manager")]
  static void CreateAsset() { typeof(InputAxisManager).CreateAsset(); }
#endif

  static InputAxisManager _instance = null;

  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
  static void LoadAsset()
  {
    if (_instance != null) { return; }
    _instance = Resources.LoadAll<InputAxisManager>("")[0];
  }


  [Header("X 方向に移動するキー")]
  [SerializeField, OpenField("_name")]
  InputAxis _horizontal = null;

  [Header("Z 方向に移動するキー")]
  [SerializeField, OpenField("_name")]
  InputAxis _vertical = null;

  public static int x { get { return _instance._horizontal.axis; } }
  public static int z { get { return _instance._vertical.axis; } }

  public static bool isLeft
  {
    get { return (x < 0 && _instance._horizontal.isPush); }
  }

  public static bool isRight
  {
    get { return (x > 0 && _instance._horizontal.isPush); }
  }

  public static bool isDown
  {
    get { return (z < 0 && _instance._vertical.isPush); }
  }

  public static bool isUp
  {
    get { return (z > 0 && _instance._vertical.isPush); }
  }


  [Header("押されている間、移動を禁止するキー")]
  [SerializeField, OpenField("_name")]
  InputAxis _lockMove = null;

  public static bool isLockMove { get { return _instance._lockMove.isPress; } }

  [Header("押されている間、斜め移動に制限するキー")]
  [SerializeField, OpenField("_name")]
  InputAxis _diagonal = null;

  public static bool isDiagonal { get { return _instance._diagonal.isPress; } }


  [Header("カメラを回転させるキー")]
  [SerializeField, OpenField("_name")]
  InputAxis _cameraRotate = null;

  public static int cameraRotateDirection
  {
    get { return _instance._cameraRotate.axis; }
  }
}
