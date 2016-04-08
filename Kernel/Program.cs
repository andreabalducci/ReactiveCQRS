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

	public static class Runner
	{
		static ActorSystem _system;
		static IStoreEvents _eventStore;
		static IConstructAggregates _factory = new AggregateFactory();
		static IDetectConflicts _conflictsDetector = new ConflictDetector();

		static Runner ()
		{
		}

		public static void Start(){
			StartEventStore ();

			_system = ActorSystem.Create ("kernel");

			var props = Props.Create<CommandWorker>().WithRouter(new RoundRobinPool(10));
			_system.ActorOf(props, "worker");
		}
			
		public static void Stop(){
			_system.ActorSelection ("akka://kernel/user").Tell (PoisonPill.Instance);
			_system.WhenTerminated.Wait();

			_eventStore.Dispose ();
		}

		private static void StartEventStore()
		{
			_eventStore = Wireup
				.Init()
				.UsingInMemoryPersistence()
				.InitializeStorageEngine()
				.Build ();
		}


		public static IRepository GetRepository()
		{
			return new CommonDomain.Persistence.EventStore.EventStoreRepository(
				_eventStore,_factory,_conflictsDetector
			);
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Runner.Start ();

			Console.WriteLine ("KERNEL Started, press any key to stop");
			Console.ReadLine ();
			Runner.Stop ();
			Console.WriteLine ("KERNEL Stopped");
		}
	}
}
