using System;
using Akka.Actor;

namespace Kernel
{
	public class CommandWorker : UntypedActor
	{
		public CommandWorker ()
		{
			Console.WriteLine ("Command worker created");
		}

		#region implemented abstract members of UntypedActor

		protected override void OnReceive (object message)
		{
		}

		#endregion
	}
}

