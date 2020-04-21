using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Static_classes
{
    static class Parameters
    {
        private static Dictionary<string, string> Params { get; set; }

        public static void InitializeParams()
        {
            Params = new Dictionary<string, string>();
        }

        public static void ResetPrams()
        {
            Params.Clear();
        }

        public static void AddParameter(object KeyId, object KeyValue)
        {
            if (Params.ContainsKey(KeyId.ToString()))
            {
                Params[KeyId.ToString()] = KeyValue.ToString();
            }
            else
            {
                Params.Add(KeyId.ToString(), KeyValue.ToString());
            }
        }

        public static string ReturnValueByKey(object KeyId)
        {
            return Params[KeyId.ToString()];
        }
    }
}
