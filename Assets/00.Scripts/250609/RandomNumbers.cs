using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class RandomNumbers : MonoBehaviour
{
    public List<int> list_int = new List<int>();

    public List<int> my_draw = new List<int>();

    public List<int> winning_draw = new List<int>();

    // public int shuffle_count = 1000;

    private void Awake()
    {
        list_int = InitializeList();
        winning_draw = Draw(list_int, 7);
        list_int = InitializeList();
        my_draw = Draw(list_int, 7);

        Debug.Log($"Winning numbers: {winning_draw}");
        Debug.Log($"My numbers: {my_draw}");
    }

    /* Shuffle
    
    IEnumerator Start()
    {
        for (int i = 0; i < shuffle_count; i++)
        {
            int random_int_1 = Random.Range(0, int_array.Length);
            int random_int_2 = Random.Range(0, int_array.Length);

            var temp = int_array[random_int_1];
            int_array[random_int_1] = int_array[random_int_2];
            int_array[random_int_2] = temp;

            yield return new WaitForSeconds(0.2f);
        }
    }
    */

    private List<int> InitializeList()
    {
        List<int> _list = new List<int>();

        for (int i = 1; i < 46; i++)
        {
            _list.Add(i);
        }

        return _list;
    }

    private List<int> Draw(List<int> _list, int _number)
    {
        List<int> return_list = new List<int>();

        for (int i = 0; i < _number; i++)
        {
            int random_index = Random.Range(0, _list.Count);
            return_list.Add(_list[random_index]);
            _list.Remove(random_index);
        }

        return return_list;
    }


}
