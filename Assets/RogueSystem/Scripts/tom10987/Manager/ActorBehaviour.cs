
using UnityEngine;

[DisallowMultipleComponent]
public abstract class ActorBehaviour : MonoBehaviour
{
  protected virtual void Awake() { ActorManager.Add(this); }
  protected virtual void OnDestroy() { ActorManager.Remove(this); }

  // コルーチンなど、更新が完了したら true を返すようにする
  public bool updateFinished { get; protected set; }

  // １ターンあたりの行動を実行する処理を作る
  public abstract void UpdateAction();
}
