using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Static_classes
{
    static class Cache
    {
        private static Dictionary<string, string> cache { get; set; }

        public static void InitializeParams()
        {
            cache = new Dictionary<string, string>();
        }

        public static void ResetPrams()
        {
            cache.Clear();
        }

        public static void AddParameter(object KeyId, object KeyValue)
        {
            if (cache.ContainsKey(KeyId.ToString()))
            {
                cache[KeyId.ToString()] = KeyValue.ToString();
            }
            else
            {
                cache.Add(KeyId.ToString(), KeyValue.ToString());
            }
        }

        public static string ReturnValueByKey(object KeyId)
        {
            return cache[KeyId.ToString()];
        }
    }
}
