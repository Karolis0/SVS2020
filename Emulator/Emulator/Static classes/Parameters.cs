using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Static_classes
{
    static class Parameters
    {
        private static Dictionary<object, object> Params { get; set; }
        private static bool Released;

        public static void InitializeParams()
        {
            Params = new Dictionary<object, object>();
        }

        public static void ResetPrams()
        {
            Params = new Dictionary<object, object>();
        }

        public static void AddParameter(string KeyId, string KeyValue)
        {
            Params.Add(KeyId, KeyValue);
        }

        public static object ReturnValueByKey(string KeyId)
        {
            return Params[KeyId];
        }

        public static void Release()
        {
            Released = true;
        }

        public static void Hold()
        {
            Released = false;
        }

        public static bool IsReleased()
        {
            return Released;
        }
    }
}
