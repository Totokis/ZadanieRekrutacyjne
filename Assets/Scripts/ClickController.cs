using UnityEngine;

public class ClickController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                OnObjectClicked(hit.collider.gameObject);
            }
        }
    }

    private void OnObjectClicked(GameObject colliderGameObject)
    {
        Debug.Log(colliderGameObject.name + " was clicked.");
    }
}