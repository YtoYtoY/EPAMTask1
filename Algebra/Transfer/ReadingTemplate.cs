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
    /// <summary>
    /// A class describing methods for converting received strings to numbers and numbers to text for sending
    /// </summary>
    public static class ReadingTemplate
    {
        /// <summary>
        /// Getting a matrix of coefficients from a string
        /// </summary>
        /// <param name="text">File contents</param>
        /// <returns>"Left" part</returns>
        public static double[][] GetCoefficientsByTemplate(string text, string spliter)
        {
            string[] manyText = text.Split(spliter.ToCharArray());
            double[][] result = new double[manyText.Length][];

            for (int i = 0; i < manyText.Length; i++)
            {
                double[] tmpArr = Regex.Matches(manyText[i], Constants.readingDoublePattern)
                    .Cast<Match>()
                    .Select(x => double.Parse(x.Value))
                    .ToArray();
                if (tmpArr.Length != 0)
                    result[i] = tmpArr;
                else
                    result = result.Take(result.Length - 1).ToArray();

            }
            return result;
        }

        /// <summary>
        /// Getting the coefficients of the right side
        /// </summary>
        /// <param name="text">File contents</param>
        /// <returns>"Right" part</returns>
        public static double[] GetUpshotByTemplate(string text)
        {
            double[] result = Regex.Matches(text, Constants.readingDoublePattern)
                .Cast<Match>()
                .Select(x => double.Parse(x.Value))
                .ToArray();

            _ = result.Length;

            return result;
        }

        /// <summary>
        /// Converting an array of responses to a string for a text file
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
