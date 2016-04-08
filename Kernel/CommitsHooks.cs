using System;
using Akka.Actor;
using Akka.Routing;
using NEventStore;
using CommonDomain.Persistence;
using CommonDomain.Core;
using CommonDomain;

namespace Kernel
{
	public class CommitsHooks : PipelineHookBase
	{
		private IActorRef _sequencer;
		public CommitsHooks(IActorRef sequencer)
		{
			this._sequencer = sequencer;
		}

		public override void PostCommit (ICommit committed)
		{
			_sequencer.Tell (committed);
		}		
	}
}
