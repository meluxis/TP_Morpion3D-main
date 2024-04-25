using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player[] players;
    private int currentPlayerIndex = 0;
    public GameObject particule;
    private void Start()
    {
        SetPlayerColor();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                PlayCell cell = hit.collider.GetComponent<PlayCell>();
                if (cell != null && !cell.HasToken && !IsTokenBelow(cell))
                {
                    PlayInCell(cell);
                }
            }
        }
    }

    private bool IsTokenBelow(PlayCell cell)
    {
        RaycastHit hit;
        if (Physics.Raycast(cell.transform.position, Vector3.down, out hit))
        {
            PlayCell belowCell = hit.collider.GetComponent<PlayCell>();
            if (belowCell != null && belowCell.HasToken)
            {
                return true;
            }
        }
        return false;
    }

    public void PlayInCell(PlayCell cell)
    {
        GameObject token = Instantiate(players[currentPlayerIndex].tokenPrefab, cell.transform.position, Quaternion.identity);
        token.transform.SetParent(cell.transform); 
        cell.SetToken(token);
        GameObject explosion = Instantiate(particule, cell.transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, 1);
        players[currentPlayerIndex].AddPlayedPosition(cell.transform.position);

        // Check if the current player wins
        if (players[currentPlayerIndex].CheckWin())
        {
            Debug.Log("Player " + (currentPlayerIndex + 1) + " wins!");
            // You can add additional code here to handle the win condition, like stopping the game or showing a win screen.
        }
        NextPlayer();
        
    }

    private void NextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        SetPlayerColor();
    }

    private void SetPlayerColor()
    {
        Shader.SetGlobalColor("_CurrentPlayerColor", players[currentPlayerIndex].color);
    }
}
