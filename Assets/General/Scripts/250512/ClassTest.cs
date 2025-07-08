using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;

public class TestClass
{
    public int number;

    public TestClass(int _number)
    {
        this.number = _number;
    }
}

public struct TestStruct
{
    public int number;

    public TestStruct (int _number)
    {
        this.number = _number;
    }
}

public class ClassTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Class------------------------");
        TestClass class_1 = new(10);
        TestClass class_2 = class_1;
        Debug.Log($"class_1 = {class_1.number}, class_2 = {class_2.number}");
        class_1.number = 100;
        Debug.Log($"class_1 = {class_1.number}, class_2 = {class_2.number}");


        Debug.Log("Struct-----------------------");
        TestStruct struct_1 = new(10);
        TestStruct struct_2 = struct_1;
        Debug.Log($"struct_1 = {struct_1.number}, struct_2 = {struct_2.number}");
        struct_1.number = 100;
        Debug.Log($"struct_1 = {struct_1.number}, struct_2 = {struct_2.number}");

    }
    void Update()
    {
        
    }
}
