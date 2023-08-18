using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GenericEventSystem {
    public static class GenericListExtensions {
        //Remove a list from a list:
        public static void RemoveList<T>(this List<T> listToRemoveFrom, List<T> listToRemove) {
            foreach (T item in listToRemove) {
                listToRemoveFrom.Remove(item);
            }
        }
        //Clear all null values from the list
        public static void DropNa<T>(this List<T> listToRemoveFrom) {
            List<T> tmpList = new List<T>(listToRemoveFrom);
            foreach (T item in tmpList) {
                if (item == null)
                    listToRemoveFrom.Remove(item);
            }
        }
        //move element to last element in list
        public static void Move<T>(this List<T> list, int oldIndex, int newIndex) {
            T item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);
        }
        //return list randomized order
        public static List<T> Shuffle<T>(this List<T> listToRemoveFrom) {
            List<T> outputList = new List<T>();
            List<T> items = new List<T>(listToRemoveFrom);
            foreach (T item in listToRemoveFrom) {
                T randomItem = items[Random.Range(0, items.Count)];
                outputList.Add(randomItem);
                items.Remove(randomItem);
            }
            return outputList;
        }
        public static T[, ] ToSquareArray<T>(this IList<T> source) {
            if (source == null) {
                throw new System.ArgumentNullException("source");
            }

            int size = Mathf.CeilToInt(Mathf.Sqrt(source.Count()));

            var result = new T[size, size];
            int step = 0;
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    result[i, j] = source[step];
                    step++;
                }
            }

            return result;
        }
    }
}