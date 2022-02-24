using System.Collections;
using System.Collections.Generic;

using libcs.Types.Unmanaged;

namespace libcs
{

    public static class Environment {
        
        internal static List<KeyValuePair<string, string>> Items;

        public static void Init(App app) {
            Items = new List<KeyValuePair<string, string>>();
            foreach (var item in app.environment)
            {
                
            }
            
        }

        public static void Set(string Key, string Value) {
            foreach (var item in Items)
            {
                if(item.Key == Key)
                {
                    Items.Remove(item);
                    continue;
                }
            }

            Items.Add(new KeyValuePair<string, string>(Key, Value));

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