using System;
using Akka.Actor;
using Akka.Routing;
using NEventStore;
using CommonDomain.Persistence;
using CommonDomain.Core;
using CommonDomain;

namespace Kernel
{
	public class AggregateFactory : IConstructAggregates
	{
		public IAggregate Build (Type type, Guid id, IMemento snapshot)
		{
			return (IAggregate)Activator.CreateInstance (type);
		}
	}
	
}
