using System;
using System.Collections.Generic;
using System.Text;

namespace DM_State
{
    public class State
    {
        public Dictionary<string, SetTheory.ISet<long>> Variables;

        public State()
        {
            Variables = new Dictionary<string, SetTheory.ISet<long>>();
        }

        public bool IsSubstate(State other)
        {
            foreach (var keyValuePair in other.Variables)
            {
                if (Variables.TryGetValue(keyValuePair.Key, out var value))
                {
                    var comparedValue = keyValuePair.Value.CompareTo(value);
                    // Check if the value 
                    if (comparedValue == 1 || comparedValue == 0)
                    {
                        continue;
                    }
                    return false;
                }
            }
            return true;

        }
    }
}
