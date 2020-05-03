using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGDS_Recommendation_System
{
	public class IrisDTO
	{
		public float SepalLength { get; set; }
		public float SepalWidth { get; set; }
		public float PetalLength { get; set; }
		public float PetalWidth { get; set; }
		public string Species { get; set; }

		public IrisDTO(IReadOnlyList<string> iris)
		{
			if (iris.Count != 5)
				throw new ArgumentException();
			SepalLength = float.Parse(iris[0], CultureInfo.InvariantCulture);
			SepalWidth = float.Parse(iris[1], CultureInfo.InvariantCulture);
			PetalLength = float.Parse(iris[2], CultureInfo.InvariantCulture);
			PetalWidth = float.Parse(iris[3], CultureInfo.InvariantCulture);
			Species = iris[4];
		}
	}
}
