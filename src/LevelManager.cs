using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {

	void Start () {
		// subscrib to the event bus somewhere
		EventBus.getInstance ().subscribe (this);
	}

	public void onDiamondEvent(DiamondEvent dEvent) {
		if (dEvent.hasBeenEaten) {
			print("Diamond has been eaten!")
		}
	}
}
