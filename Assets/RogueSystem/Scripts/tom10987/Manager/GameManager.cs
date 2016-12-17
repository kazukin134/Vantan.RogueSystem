
using UnityEngine;

public class GameManager : ScriptableObject
{
#if UNITY_EDITOR
  [UnityEditor.MenuItem("Custom Assets/Create Game Manager", priority = 1)]
  static void CreateAsset() { typeof(GameManager).CreateAsset(); }
#endif

  static GameManager _instance = null;

  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
  static void LoadAsset()
  {
    if (_instance != null) { return; }
    _instance = Resources.LoadAll<GameManager>("")[0];
  }


  /// <summary> ゲーム開始からの経過ターン数 </summary>
  public static int elapsedTurn { get; private set; }

  /// <summary> ターン数のカウントを進める </summary>
  public static void UpdateTurnCount() { ++elapsedTurn; }

  /// <summary> ターン数のカウントを０にする </summary>
  public static void ResetTurnCount() { elapsedTurn = 0; }

  int _previous = 0;

  /// <summary> プレイヤーがカウントを更新していたら true を返す </summary>
  public static bool playerAction
  {
    get
    {
      bool action = (elapsedTurn != _instance._previous);
      if (action) { _instance._previous = elapsedTurn; }
      return action;
    }
  }


  [Header("昼の長さ：昼ターン数")]
  [SerializeField, Range(16, 128)]
  int _day = 32;

  [Header("夜の長さ：夜ターン数")]
  [SerializeField, Range(16, 128)]
  int _night = 32;

  /// <summary> １日の長さ：昼と夜の合計ターン </summary>
  public static int dayTurnLength { get { return _instance._day + _instance._night; } }

  /// <summary> 経過ターン数が昼の状態なら true を返す </summary>
  public static bool isDayTurn
  {
    get { return (elapsedTurn % dayTurnLength) < _instance._day; }
  }
}
