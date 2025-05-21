using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    // setting the array to public allows you to view array elements in the Unity inspector window
    // if instance access is not specified, it defaults to private
    public int[] intArray = new int[5] { 1, 2, 3, 4, 5 };

    public List<int> intList = new();

    // Start() and Update() methods also default to private
    void Start()
    {
        // remember that arrays start at 0
        Debug.Log($"Array Position 1: {intArray[0]}");
        Debug.Log($"Array Position 3: {intArray[2]}");
        Debug.Log($"Array Position 6: {intArray[4]}");

        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);
        intList.Add(5);
        intList.Add(42);

        Debug.Log($"List item count: {intList.Count}");
        Debug.Log($"List Position 2: {intList[2]}");
        Debug.Log($"Last item in list: {intList[intList.Count - 1]}");
        // new syntax for end-of-list
        Debug.Log($"Last item in list: {intList[^1]}");


    }
}
