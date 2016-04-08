using System;
using Akka.Actor;
using Akka.Routing;

namespace Kernel
{
	public static class Runner
	{
		static ActorSystem _system;

		static Runner ()
		{
		}


		public static void Start(){
			_system = ActorSystem.Create ("kernel");

			var props = Props.Create<CommandWorker>().WithRouter(new RoundRobinPool(10));
			var worker = _system.ActorOf(props, "worker");
		}
			
		public static void Stop(){
			_system.ActorSelection ("akka://kernel/user").Tell (PoisonPill.Instance);
			_system.WhenTerminated.Wait();
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
