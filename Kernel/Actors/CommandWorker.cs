using System;
using Akka.Actor;

namespace Kernel
{
	//
	// Command handling
	//  1. store command on disk / db
	//  2. delegate to aggregate handler (router by aggregate id)
	//  3. update ( or delete? ) command on disk
	//
	public class CommandWorker : UntypedActor
	{
		public CommandWorker ()
		{
			Console.WriteLine ("Command worker created");
		}

		#region implemented abstract members of UntypedActor

		protected override void OnReceive (object message)
		{
			Console.WriteLine ("[{0} ({1})] processing {2}", 
				Self.Path,
				Self.Path.Uid,
				message.GetType ().Name
			);
		}

		#endregion
	}
}

