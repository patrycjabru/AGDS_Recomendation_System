using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System.KNN
{
	public class KNN
	{
		private int k;
		public List<Tuple<double, EntityNode>> RankTable { get; set; }

		public KNN(int k)
		{
			this.k = k;
		}

		public List<EntityNode> FindNeighbors(EntityNode node)
		{
			RankTable = new List<Tuple<double, EntityNode>>();
			var firstAttributeValues = node.AttributeValues[0].Attribute.Values;
			var topClosestValues = FindClosestValues(firstAttributeValues, node.AttributeValues[0]);

			foreach (var nextClosestValue in topClosestValues)
			{
				foreach (var entity in nextClosestValue.Value.Entities)
				{
					var distance = CalculateDistance(entity, node);
					RankTable.Add(new Tuple<double, EntityNode>(distance, entity));
				}
			}

			return RankTable.OrderByDescending(x => x.Item1).Select(x => x.Item2).Take(k).ToList();
		}

		private float CalculateDistance(EntityNode entity, EntityNode node)
		{
			var totalDistance = 0.0F;
			for (var i = 0; i < entity.AttributeValues.Count; i++)
			{
				var singleDistance = Math.Abs(node.AttributeValues[i].Value - entity.AttributeValues[i].Value);
				totalDistance += singleDistance;
			}

			return totalDistance;
		}

		private SortedList<double, ValueNode> FindClosestValues(SortedList<double, ValueNode> valuesList, ValueNode inputValue)
		{
			var topClosestList = new SortedList<double, ValueNode>();
			foreach (var v in valuesList)
			{
				topClosestList.Add(v.Value.Value - inputValue.Value, v.Value);
			}

			return topClosestList;
		}
	} 
}
