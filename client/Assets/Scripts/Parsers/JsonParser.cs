using System.IO;
using UnityEngine;

namespace Parsers
{
    public static class JsonParser
    {
        public static T FromFile<T>(string path)
        {
            if (!File.Exists(path))
                return default(T);

            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
    }
}