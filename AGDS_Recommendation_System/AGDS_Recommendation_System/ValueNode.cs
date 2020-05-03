using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System
{
	public class ValueNode
	{
		public float Value { get; set; }
		public AttributeNode Attribute { get; set; }
		public EntityNode Entity { get; set; }

		public ValueNode(float value, AttributeNode attribute, EntityNode entity)
		{
			Value = value;
			Attribute = attribute;
			Entity = entity;
		}
	}
}
