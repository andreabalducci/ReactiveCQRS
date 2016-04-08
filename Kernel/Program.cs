using System;
using Akka.Actor;
using Akka.Routing;
using NEventStore;
using CommonDomain.Persistence;
using CommonDomain.Core;
using CommonDomain;

namespace Kernel
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Runner.Start ();

			Console.WriteLine ("KERNEL Started, press any key to stop");

			Runner.Sample ();

			Console.ReadLine ();
			Runner.Stop ();
			Console.WriteLine ("KERNEL Stopped");
		}
	}
}
