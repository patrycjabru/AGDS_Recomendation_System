using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System
{
	public class EntityNode
	{
		public int Id { get; set; }
		public List<ValueNode> AttributeValues { get; set; }
		public ValueClassNode ClassValue { get; set; }

		public EntityNode(int id)
		{
			Id = id;
		}
	}
}
