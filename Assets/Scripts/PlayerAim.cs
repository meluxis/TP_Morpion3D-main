using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera camera;
    private PlayCell currentHoveredCell;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        HandleMouseHover();
        HandleMouseClick();
    }

    private void HandleMouseHover()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            PlayCell cell = hit.collider.GetComponent<PlayCell>();
            if (cell != null && cell != currentHoveredCell)
            {
                if (currentHoveredCell != null)
                {
                    currentHoveredCell.OnHoverExit();
                }
                cell.OnHoverEnter();
                currentHoveredCell = cell;
            }
        }
        else if (currentHoveredCell != null)
        {
            currentHoveredCell.OnHoverExit();
            currentHoveredCell = null;
        }
    }

    private void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // Bouton gauche de la souris
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                PlayCell cell = hit.collider.GetComponent<PlayCell>();
                if (cell != null)
                {
                    Debug.Log($"Cell clicked at coordinates: {cell.coords}");
                }
            }
        }
    }
}
