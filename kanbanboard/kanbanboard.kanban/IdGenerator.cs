using kanbanboard.contracts;
using System;

namespace kanbanboard.kanban
{
	public class IdGenerator : IIdGenerator
	{
		public string CreateId()
		{
			Guid g = Guid.NewGuid();

			return g.ToString();
		}
	}
}
