
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ActorManager : Singleton<ActorManager>
{
  static readonly List<ActorBehaviour> _actors = new List<ActorBehaviour>();

  public static void Add(ActorBehaviour actor) { _actors.Add(actor); }
  public static void Remove(ActorBehaviour actor) { _actors.Remove(actor); }

  public static T GetActor<T>() where T : ActorBehaviour
  {
    return _actors.FirstOrDefault(actor => actor is T) as T;
  }

  public static T[] GetActors<T>() where T : ActorBehaviour
  {
    return _actors.Select(actor => actor is T).Cast<T>().ToArray();
  }

  IEnumerator Start()
  {
    while (exists)
    {
      yield return null;

      if (!_actors.All(actor => actor.updateFinished)) { continue; }
      if (!GameManager.playerAction) { continue; }

      int length = _actors.Count;
      for (int i = 0; i < length; ++i) { _actors[i].UpdateAction(); }
    }
  }
}
