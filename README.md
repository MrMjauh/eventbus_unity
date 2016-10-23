### Simple eventbus for unity using reflection
The EventBus class is a singleton class used to communicate events in a decoupled manner.  If you want to listen for event, start of the class by calling:
  - EventBus.getInstance ().subscribe (this), where this is a class derived from MonoBehaviour

and them create methods that has on inargument with classes derived from the BaseEvent (see example).
To publish event just write:
  - EventBus.getInstance ().publish (new SomeEvent ()).

### Missing
-   Only check for method in the implemented code, not the super class(es)

### Constraints
Since this class is not written in a super general purpose, all listeners needs to extend the MonoBehaviour class (see example code).
