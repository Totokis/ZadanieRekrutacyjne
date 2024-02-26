using UnityEngine;

public class ClickController : MonoBehaviour
{
    [SerializeField] private TargetManager targetManager;
    [SerializeField] private Camera mainCamera;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                OnObjectClicked(hit.collider.gameObject);
            }
        }
    }

    private void OnObjectClicked(GameObject colliderGameObject)
    {
        targetManager.Hit(colliderGameObject);
    }
}