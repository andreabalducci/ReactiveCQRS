using System;
using Akka.Actor;
using NEventStore;

namespace Kernel
{
	public class CommitsSequencer : ReceiveActor
	{
		public CommitsSequencer ()
		{
			Receive<ICommit> (c => {
				Console.WriteLine ("Received {0}", c.CheckpointToken);
			});
		}
	}
}

