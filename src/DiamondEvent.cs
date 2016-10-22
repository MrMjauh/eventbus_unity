using System;


public class DiamondEvent : BaseEvent
{
	public bool hasBeenEaten;

	public DiamondEvent(bool hasBeenEaten) {
		this.hasBeenEaten = hasBeenEaten;
	}
}
