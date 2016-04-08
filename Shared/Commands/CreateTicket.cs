using System;

namespace Shared
{
	public class CreateTicket
	{
		public string Id { get; private set;}
		public CreateTicket (string id)
		{
			this.Id = id;
		}
	}
}

