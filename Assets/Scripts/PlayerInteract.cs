using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Проведите Raycasting или другие методы для определения объекта перед игроком
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
            {
                IInteract interactable = hit.collider.GetComponent<IInteract>();
                if (interactable != null)
                {
                    interactable.Action();
                    // Debug.Log("Action!!!!");
                }
            }
        }
    }
}
