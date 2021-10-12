using System.Collections;
using System.Collections.Generic;

namespace libcs
{

    public static class Environment {
        
        internal static List<KeyValuePair<string, string>> Items = new List<KeyValuePair<string, string>>();

        public static void Init(App app) {
            Items = new List<KeyValuePair<string, string>>(app.environment);
            
        }

        public static string Get(string Key) {
            foreach (var item in Items)
            {
                if(item.Key == Key) return item.Value;
            }
            return null;
        }

        public static bool TryGet(string Key, out string Value) {
            var item = Get(Key);
            if(item != null)
            {
                Value = item;
                return true;
            }
            Value = null;
            return false;
        }

    }
    
}