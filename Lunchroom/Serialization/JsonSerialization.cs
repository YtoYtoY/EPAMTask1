using Lunchroom.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Serialization
{
    public class JsonSerialization : ISerialization
    {
        /// <summary>
        /// Settings for easy reading of information
        /// </summary>
        public readonly DataContractJsonSerializerSettings Settings =
            new DataContractJsonSerializerSettings
            { 
                UseSimpleDictionaryFormat = true // Does not work!
            };

        /// <summary>
        /// Deserializing a collection
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="filePath">Path to file</param>
        /// <returns></returns>
        public ICollection<T> Restore<T>(string filePath)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T[]));
            List<T> restoredData = new List<T>();
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                T[] data = (T[])jsonFormatter.ReadObject(fileStream);
                restoredData.AddRange(data);
            }
            return restoredData;
        }

        /// <summary>
        /// Serializing a collection
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="data">Coollection</param>
        /// <param name="path">Path to file</param>
        public void Save<T>(ICollection<T> data, string path)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(T[]), Settings);
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fileStream, data.ToArray());

            }
        }
    }
}
