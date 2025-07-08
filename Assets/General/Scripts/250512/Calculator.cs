using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number_1, number_2;

    void Start()
    {
        int addResult = AddMethod();
        int minusResult = MinusMethod();

        Debug.Log($"Added: {addResult}, Subtracted: {minusResult}");
    }

    int AddMethod()
    {
        int result = number_1 + number_2;

        return result;
    }

    int MinusMethod()
    {
        int result = number_1 - number_2;

        return result;
    }

}
