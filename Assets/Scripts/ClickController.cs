using UnityEngine;

public class ClickController : MonoBehaviour
{

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject == gameObject)
                {

                    OnObjectClicked();
                }
            }
        }
    }

    private void OnObjectClicked()
    {

        Debug.Log(gameObject.name + " was clicked.");
    }
}