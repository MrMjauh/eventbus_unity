# Simple eventbus for unity
The EventBus class is a singleton class used to communicate events in a decoupled manner.  If you want to listen for event, start of the class by calling
EventBus.getInstance ().subscribe (this) and the create methods that has on inargument with classes derived from the BaseEvent (see example).
To publish event just write EventBus.getInstance ().publish (new SomeEvent ()).

### Missing
-   Unsubscribe to events
-   Only check for method in the implemented code, not the derived classes
