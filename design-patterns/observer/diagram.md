# Design Diagram

```mermaid
---
title: Observer Design Pattern
---
classDiagram
    direction LR
    Client ..> Subject: uses
    Client ..> Observer
    Subject --o Observer: has a
    ConcreteSubject ..> Subject: implements
    ConcreteObserver ..> Observer: implements
    ConcreteSubject --o ConcreteObserver: has a
    class Client {
    }
    class Subject {
        <<interface>>
        + Attach(Observer)
        + Detach(Observer)
        + Notify()
    }
    class Observer {
        <<interface>>
        + Update(context)
    }
    class ConcreteSubject {
        - observers
        - state
        + Attach(Observer)
        + Detach(Observer)
        + Notify()
    }
    class ConcreteObserver {
        - subject
        + Update(context)
    }
```
