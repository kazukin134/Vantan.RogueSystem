
using UnityEngine;

[DisallowMultipleComponent]
public abstract class ActorBehaviour : MonoBehaviour
{
  protected virtual void Awake() { ActorManager.Add(this); }
  protected virtual void OnDestroy() { ActorManager.Remove(this); }

  public virtual bool isAwake { get { return true; } }

  public abstract void UpdateAction(float deltaTime);
}
