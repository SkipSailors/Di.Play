# Di.Play
It has been tricky in the past to support the Decorator pattern and IoC at the same time in .NET code.  Multicast interfaces are tricky to begin with.  If you need two instances of the same service, that are both the same implemtnation of the service, but vary only in the parameters that are used in the constructor, it can be difficult to deliver the two instances to an application.  Creative use of the factory methods in Add...<>() bindings results.

.NET 8 provides Keyed Services.  This demonstration has two instances of the same implementation of the same interface registered in the DI container to get two different results.
