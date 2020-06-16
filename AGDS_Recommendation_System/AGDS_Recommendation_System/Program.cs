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

			var neighborsNumber = 0;
			while (true)
			{
				Console.WriteLine("Write a number of neighbors to find");
				neighborsNumber = Convert.ToInt32(Console.ReadLine());
				if (neighborsNumber >= 0 && neighborsNumber < entities.Count)
					break;
				Console.WriteLine("\nInvalid input\n");
			}
			var knn = new KNN.KNN(neighborsNumber);

			var entityNumber = 0;
			while (true)
			{
				Console.WriteLine("Write a number of entity");
				entityNumber = Convert.ToInt32(Console.ReadLine());
				if (entityNumber >= 0 && entityNumber < entities.Count)
					break;
				Console.WriteLine("\nInvalid input\n");
			}

			var neighbors = knn.FindNeighbors(entities[entityNumber]);

			Console.WriteLine($"\nNeighbors of node number {entities[entityNumber].Id} are nodes:");
			foreach (var n in neighbors)
			{
				Console.WriteLine(n.Id);
			}

			Console.ReadKey();
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
