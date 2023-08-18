using System.Collections.Generic;
using UnityEngine;
namespace GenericEventSystem {
    [System.Serializable]
    public class SettableNameList {
        [SerializeField]
        public List<string> list;
        [SerializeField]
        public List<int> indexes;
    }
}