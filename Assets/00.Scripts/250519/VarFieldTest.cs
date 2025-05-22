using UnityEngine;

public class VarFieldTest : MonoBehaviour
{
    // field(s). public variables are serialized by Unity, private variables are not.
    // ref https://www.reddit.com/r/Unity3D/comments/13sbkgj/beginner_tutorial_serializefield_in_unity/
    // tl;dr Unity reconstructs scripts every time you change anything (and on other occasions not mentioned). Serialization is Unity's way of keeping a record of variables instead of renewing them each time.
    // int number_1 = 1;
   //  private int number_2 = 2;
    public int number_3 = 3;

    // forces Unity to serialize a private variable. same as below, different syntax
    // [SerializeField]
    // private int number_4 = 4;

    // same as above, different syntax
    // [SerializeField] int number_5 = 5;

    // does the opposite of above
    [System.NonSerialized] public int number_6 = 6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

}
