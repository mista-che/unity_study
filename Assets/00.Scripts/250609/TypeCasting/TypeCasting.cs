using System;
using UnityEngine;

public class TypeCasting : MonoBehaviour
{
    public enum ThreeFruits { Peach, Apple, Mango }
    public ThreeFruits three_fruits = new();

    void Start()
    {
        int int_ = 1;
        float float_ = 10.5f;

        // int_ = float_; << COMPILER ERROR
        // explicit cast required, you can't cast a float -> int, but you can cast an int -> float

        int_ = (int)float_; // explicit cast of float -> int. has the potential to lose data.
        Debug.Log(int_);    // for example, a value of 10.5(float) will truncate to 10(int), losing data related to the decimal value.

        Vector3 vector_ = new(10, 10, 10); // C# is casting 10(int) -> 10(float) required for Vector objects

        string string_1 = "123";
        string string_2 = "456";
        Debug.Log("String: " + string_1 + string_2);

        int number_1 = int.Parse(string_1);
        int number_2 = int.Parse(string_2);
        Debug.Log("Int: " + number_1 + number_2); // returns 123456 instead of the sum, 579
        Debug.Log("Int Sum:" + (number_1 + number_2)); // returns the sum


        // Convert.ToBoolean();

        int num0 = 0;         // false
        int num1 = 1;         // true
        int num2 = 2;         // true
        int num100 = 100;     // true

        float fNum0 = 0f;     // false
        float fNum1 = 1.57f;  // true
        float fNum2 = 3.14f;  // true


        // string str1 = "Hello"; // error
        string str2 = "true";  // true
        string str3 = "false"; // false

        Debug.Log("Num0 : " + Convert.ToBoolean(num0));
        Debug.Log("Num1 : " + Convert.ToBoolean(num1));
        Debug.Log("Num2 : " + Convert.ToBoolean(num2));
        Debug.Log("Num100 : " + Convert.ToBoolean(num100));

        Debug.Log("fNum0 : " + Convert.ToBoolean(fNum0));
        Debug.Log("fNum1 : " + Convert.ToBoolean(fNum1));
        Debug.Log("fNum2 : " + Convert.ToBoolean(fNum2));

        // Debug.Log("str1 : " + Convert.ToBoolean(str1));
        Debug.Log("str2 : " + Convert.ToBoolean(str2));
        Debug.Log("str3 : " + Convert.ToBoolean(str3));


        // Convert.ToInt32();
        bool is_true = true;
        bool is_false = false;
        int num00 = Convert.ToInt32(is_true);  // 1
        int num01 = Convert.ToInt32(is_false); // 0
        Debug.Log(num00);
        Debug.Log(num01);

        // Orc and Goblin are subclasses of Monster
        Orc orc = new();
        Goblin goblin = new();

        // Can cast Orc and Goblin to parent class, Monster
        Monster monster_1 = (Monster)orc;
        Monster monster_2 = (Monster)goblin;

        // Can cast Monsters to child classes, Orc and Goblin. However, this may not work because it carries the risk of losing data.
        Monster monster_3 = new();
        Monster monster_4 = new();
        Orc orc_monster = (Orc)monster_3;
        Goblin goblin_monster = (Goblin)monster_4;
    }
}
