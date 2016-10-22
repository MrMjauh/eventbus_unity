using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		EventBus.getInstance ().publish (new DiamondEvent (true));
	}
}
