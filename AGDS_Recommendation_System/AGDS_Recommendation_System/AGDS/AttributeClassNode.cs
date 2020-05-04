using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System
{
	public class AttributeClassNode
	{
		public string Name { get; set; }
		public List<ValueClassNode> Values { get; set; }

		public AttributeClassNode(string name)
		{
			Name = name;
			Values = new List<ValueClassNode>();
		}

		public ValueClassNode AddValue(string value, EntityNode entityNode)
		{
			var node = Values.SingleOrDefault(x => x.Value.Equals(value));
			if (node != null)
				return node;
			var valueNode = new ValueClassNode(value, this, entityNode);
			Values.Add(valueNode);
			return valueNode;
		}
	}
}
