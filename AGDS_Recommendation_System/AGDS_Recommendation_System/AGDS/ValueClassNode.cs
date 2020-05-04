using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System
{
	public class ValueClassNode
	{
		public string Value { get; set; }
		public AttributeClassNode Attribute { get; set; }
		public EntityNode Entity { get; set; }

		public ValueClassNode(string value, AttributeClassNode attribute, EntityNode entity)
		{
			Value = value;
			Attribute = attribute;
			Entity = entity;
		}
	}
}
