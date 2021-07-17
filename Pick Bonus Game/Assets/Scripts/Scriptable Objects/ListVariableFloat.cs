// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------
using UnityEngine;

namespace Modular
{
    [CreateAssetMenu]
    public class ListVariableFloat: ListVariable<float>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public void AddOne(int index)
        {
            ListValue[index] = ListValue[index] + 1;
        }

        public void RemoveOne(int index)
        {
            ListValue[index] = ListValue[index] - 1;
        }

        // does minValue exist in the array?
        public bool ValueAtLeast(int minValue)
        {
            for (int i = 0; i < ListValue.Count; i++)
            {
                if (ListValue[i] >= minValue)
                    return true;
            }
            return false;
        }

        // return the first index of ListValue that is equal or greater than minValue, otherwise return -1
        public int IndexOfValueAtLeast(int minValue)
        {
            for (int i = 0; i < ListValue.Count; i++)
            {
                if (ListValue[i] >= minValue)
                    return i;
            }
            return -1;
        }

        // useful for finding out teammate assignments
       public int FindIndexWithSameValue(int value, int excludeIndex)
        {
            for (int i = 0; i < ListValue.Count; i++)
            {
                if (i != excludeIndex && ListValue[i] == value)
                    return i;
            }
            return excludeIndex;
        }
    }
}