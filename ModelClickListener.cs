
using UnityEngine;

public class ModelClickListener : MonoBehaviour
{
    public void HandleClick()
    {
        Debug.Log("User click");
    }

    private void OnMouseDown()
    {
        HandleClick();
    }
}
