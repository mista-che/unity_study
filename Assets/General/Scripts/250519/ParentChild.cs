using UnityEngine;

public class ParentChild : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"Object Name: {this.name}");
        Debug.Log($"# of Children: {this.transform.childCount}");
        Debug.Log($"First Child: {this.transform.GetChild(0).name}");
        Debug.Log($"Final Child: {this.transform.GetChild(this.transform.childCount - 1).name}");
        // returned "1, EmptyChild, EmptyChild" respectively b/c they were all children of children.
        // changing all children to be child of the parent returned "7, EmptyChild, EmptyChild (6)"
    }
}
