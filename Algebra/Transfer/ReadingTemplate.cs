using Algebra.Classes;
using Algebra.SLAE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algebra.Transfer
{
    public static class ReadingTemplate
    {
        public static double[][] GetCoefficientsByTemplate(string text)
        {
            string[] manyText = text.Split('\n');
            double[][] result = new double[manyText.Length][];

            for (int i = 0; i < manyText.Length; i++)
            {
                double[] tmpArr = Regex.Matches(manyText[i], Constants.readingDoublePattern)
                    .Cast<Match>()
                    .Select(x => double.Parse(x.Value))
                    .ToArray();
                result[i] = tmpArr;
            }

            return result;
        }

        public static double[] GetUpshotByTemplate(string text)
        {
            double[] result = Regex.Matches(text, Constants.readingDoublePattern)
                .Cast<Match>()
                .Select(x => double.Parse(x.Value))
                .ToArray();

            _ = result.Length;

            return result;
        }

        public static string SetToString(double[] data)
        {
            string result = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                result += data[i];
                result += '\n';
            }
            return result;
        }
    }
}
