using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System
{
	public class Program
	{
		static void Main(string[] args)
		{
			var data = LoadData();
			var attributes = new List<AttributeNode>()
			{
				new AttributeNode("SepalLength"),
				new AttributeNode("SepalWidth"),
				new AttributeNode("PetalLength"),
				new AttributeNode("PetalWidth")
			};
			var classAttribute = new AttributeClassNode("Species");
			var entities = MigrateData(data, attributes, classAttribute);


			var knn = new KNN.KNN(3);

			var neighbors = knn.FindNeighbors(entities[0]);

			Console.WriteLine($"Neighbors of node number {entities[0].Id} are nodes:");
			foreach (var n in neighbors)
			{
				Console.WriteLine(n.Id);
			}
		}

		public static List<EntityNode> MigrateData(List<IrisDTO> data, List<AttributeNode> attributes, AttributeClassNode attributeClassNode)
		{
			var id = 0;
			var entities = new List<EntityNode>();
			foreach (var d in data)
			{
				var entityNode = new EntityNode(id);
				var entityValueNodes = new List<ValueNode>()
				{
					attributes[0].AddValue(d.SepalLength, entityNode),
					attributes[1].AddValue(d.SepalWidth, entityNode),
					attributes[2].AddValue(d.PetalLength, entityNode),
					attributes[3].AddValue(d.PetalWidth, entityNode)
				};
				var classValue = attributeClassNode.AddValue(d.Species, entityNode);

				entityNode.AttributeValues = entityValueNodes;
				entityNode.ClassValue = classValue;
				entities.Add(entityNode);
				id++;
			}

			return entities;
		}
		
		public static List<IrisDTO> LoadData()
		{
			List<IrisDTO> iris = File.ReadLines("..\\..\\iris.data")
				.Select(line => line.Split(','))
				.Select(line => new IrisDTO(line))
				.ToList();
			return iris;
		}
	}
}
