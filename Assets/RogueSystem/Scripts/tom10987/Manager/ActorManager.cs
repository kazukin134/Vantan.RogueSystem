
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[DisallowMultipleComponent]
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

			float deltaTime = Time.deltaTime;

			for (int i = 0, count = _actors.Count; i < count; ++i)
			{
				if (!_actors[i].isAwake) { continue; }
				_actors[i].UpdateAction(deltaTime);
			}
		}

		Debug.Log("actor manager finish");
	}
}
