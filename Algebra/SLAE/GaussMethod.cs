using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra.SLAE
{
	/// <summary>
	/// Gauss method
	/// </summary>
	public class GaussMethod : SolveMethod
    {

		public GaussMethod(double[][] leftPart, double[] rightPart)
            : base(leftPart, rightPart)
        {
        }

		public override void TrySolve(double[][] leftPart, IReadOnlyList<double> rightPart)
		{
			int a = rightPart.Count;
			double k;
			int i = 1;
			int j = 0;
			double[,] Mas = new double[a, a + 1];

			for (i = 0; i < a; i++)
			{
				for (j = 0; j < a; j++)
				{
					Mas[i, j] = leftPart[i][j];
				}
				Mas[i, a] = rightPart[i];
			}

			for (int z = 0; z < a; z++)
			{
				for (i = z + 1; i < a; i++)
				{
					k = -Mas[i, z] / Mas[z, z];

					for (j = z; j <= a; j++)
					{
						Mas[i, j] = Mas[i, j] + Mas[z, j] * k;
					}
				}

			}
			double c;

			for (i = a - 1; i >= 0; i--)
			{
				c = 0;
				if (i < a - 1)
				{
					double b = Answer[i + 1];
					for (int z = i; z >= 0; z--)
					{
						Mas[z, i + 1] = Mas[z, i + 1] * b;
					}
				}
				for (j = a; j > i; j--)
				{
					if (j == a)
					{
						c = c + Mas[i, j];
					}

					else c = c - Mas[i, j];

				}
				Answer[i] = c / Mas[i, i];
			}
			for (int p = 0; p < Answer.Length; p++)
            {
				Answer[p] = Math.Round(Answer[p], 7);
            }
		}
	}
}
