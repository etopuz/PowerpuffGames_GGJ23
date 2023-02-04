using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public static class ListExtensions
{
    public static T ReturnRandomElement<T>(this List<T> myList)
    {
        return myList[UnityEngine.Random.Range(0, myList.Count)];
    }
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        Random rng = new Random();
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static Stack<T> ToStack<T>(this List<T> list)
    {
        Stack<T> stack = new Stack<T>();
        foreach (var item in list)
        {
            stack.Push(item);
        }
        return stack;
    }

}
