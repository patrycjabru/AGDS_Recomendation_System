using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System
{
	public class AttributeNode
	{
		public string Name { get; set; }
		public SortedList<double, ValueNode> Values { get; set; }

		public AttributeNode(string name)
		{
			Name = name;
			Values = new SortedList<double, ValueNode>();
		}

		public ValueNode AddValue(float value, EntityNode entityNode)
		{
			var node = Values.SingleOrDefault(x => x.Value.Value.Equals(value)).Value;
			if (node != null)
			{
				node.AddEntity(entityNode);
				return node;
			}
			var valueNode = new ValueNode(value, this, entityNode);
			Values.Add(valueNode.Value, valueNode);
			return valueNode;

		}
	}
}
