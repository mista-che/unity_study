using LittleTimmysCode;
using UnityEngine;

public class CoworkngTestB : MonoBehaviour
{
    // must include "using LittleTimmysCode" in order to access this class

    // public CoworkingTestA ctA = new();
    public CoworkingTestA ctA; // we don't need the "new()" constructor, as the objets are already in Unity (?)
    // the above line doesn't actually assign class "CoworkingTestA" to an object because scripts are data
    // the object wrappers are created separately as EmptyGameObjects in Unity
    private void Start()
    {
        // ctA.number_1 = 10; These lines don't work because only "number_2" is public.
        ctA.number_2 = 20;
        // ctA.number_3 = 30;
        // ctA.number_4 = 40;

        // however, running this above as is throws a NullReferenceException error because
        // you cannot create a new MonoBehavior script using generic class constructors.
        // You need to add the script separately (either in the Unity inspector or other methods) in order to access the other script.
        // This sets GameObjectA's number_2 to 20. Not GameObjectB.
    }
}
