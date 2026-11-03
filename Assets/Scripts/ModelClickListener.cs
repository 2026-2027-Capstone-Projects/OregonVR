
using UnityEngine;

public class ModelClickListener : MonoBehaviour
{
    public void HandleClick()
    {
        Debug.Log("broken");
    }

    private void OnMouseDown()
    {
        HandleClick();
    }
}
