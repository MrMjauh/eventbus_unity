using UnityEngine;

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;


public class EventBus
{

	private static EventBus instance;

	// event name and the list of (object reference,methodNameToCall)
	private Dictionary<string, List<ObjectHolder>> eventsAndSubs;

	private class ObjectHolder
	{
		public MonoBehaviour objectRef;
		public MethodInfo mInfo;

		public ObjectHolder(MonoBehaviour objectRef,MethodInfo mInfo) {
			this.objectRef = objectRef;
			this.mInfo = mInfo;
		}
	}

	private EventBus ()
	{
		eventsAndSubs = new Dictionary<string, List<ObjectHolder>> ();
	}


	public static EventBus getInstance ()
	{
		if (instance == null) {
			instance = new EventBus ();
		}
		return instance;
	}

	public void publish(BaseEvent baseEvent) {
		List<ObjectHolder> listOfObjects;
		eventsAndSubs.TryGetValue (baseEvent.GetType ().Name, out listOfObjects);

		if (listOfObjects != null) {
			foreach (ObjectHolder holder in listOfObjects) {
				object[] paramList = new object[]{baseEvent};
				holder.mInfo.Invoke (holder.objectRef, paramList);
			}
		}
	}

	public void unSubscribe (MonoBehaviour subscriber)
	{

		foreach (var key in eventsAndSubs.Keys) {
			List<ObjectHolder> listOfObjects;
			eventsAndSubs.TryGetValue (key, out listOfObjects);
			listOfObjects.RemoveAll (obj => obj.objectRef == subscriber);
		}
	}

	public void subscribe (MonoBehaviour subscriber)
	{
		MethodInfo[] methodInfos=subscriber.GetType ().GetMethods ();

		foreach (MethodInfo mInfo in methodInfos) {
			ParameterInfo[] pInfos = mInfo.GetParameters();

			foreach (ParameterInfo pInfo in pInfos) {
				if (pInfos.Length == 1) {
					if (pInfo.ParameterType.IsSubclassOf (typeof(BaseEvent))) {
						string eventName = pInfo.ParameterType.Name;

						if (!eventsAndSubs.ContainsKey (eventName)) {
							eventsAndSubs.Add (eventName, new List<ObjectHolder> ());
						}

						List<ObjectHolder> listOfObjects;
						eventsAndSubs.TryGetValue (eventName, out listOfObjects);
						string methodName = mInfo.Name;
						ObjectHolder objHolder = new ObjectHolder (subscriber,mInfo);
						listOfObjects.Add (objHolder);
						//Debug.Log (subscriber.GetType().Name + " just subrscribed too " + eventName + " with method " + methodName);
					}
				}
			}
		}
	}
}
