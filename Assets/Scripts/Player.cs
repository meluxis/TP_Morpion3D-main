using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public GameObject tokenPrefab;
    public Color color;
    private List<Vector3Int> playedPositions = new List<Vector3Int>();

    // Method to add played position
    public void AddPlayedPosition(Vector3Int position)
    {
        playedPositions.Add(position);
    }

    // Method to check if the player has won
    public bool CheckWin()
    {
        foreach (Vector3Int position in playedPositions)
        {
            int horizontalCount = 0;
            int verticalCount = 0;
            int depthCount = 0;
            int diagonalCount1 = 0;
            int diagonalCount2 = 0;
            int diagonalCount3 = 0;
            int diagonalCount4 = 0;
            int diagonalCount5 = 0;
            int diagonalCount6 = 0;
            int ultraDiagonalCount1 =0;
            int ultraDiagonalCount2 = 0;
            int ultraDiagonalCount3 = 0;
            int ultraDiagonalCount4 = 0;

            // Check horizontal
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, 0, 0)))
                    horizontalCount++;
            }

            // Check vertical
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(0, i, 0)))
                    verticalCount++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(0, 0, i)))
                    depthCount++;
            }

            // Check diagonal (top-left to bottom-right)
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, i, 0)))
                    diagonalCount1++;
            }

            // Check diagonal (top-right to bottom-left)
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, -i, 0)))
                    diagonalCount2++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(0, i, i)))
                    diagonalCount3++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(0, i, -i)))
                    diagonalCount4++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, 0, -i)))
                    diagonalCount5++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, 0, i)))
                    diagonalCount6++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, i, i)))
                    ultraDiagonalCount1++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(-i, i, i)))
                    ultraDiagonalCount2++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, -i, i)))
                    ultraDiagonalCount3++;
            }
            for (int i = -1; i <= 1; i++)
            {
                if (playedPositions.Contains(position + new Vector3Int(i, i, -i)))
                    ultraDiagonalCount4++;
            }
            //Les Ultra Diagonal fonctionnent pas :(
            
            if (horizontalCount >= 3 || verticalCount >= 3 || depthCount >=3 || diagonalCount1 >= 3 || diagonalCount2 >= 3 || diagonalCount3 >= 3 || diagonalCount4 >=3 || diagonalCount5 >= 3 || diagonalCount6 >= 3)
                return true;
        }

        return false;
    }
    public void AddPlayedPosition(Vector3 position)
    {
        Vector3Int positionInt = new Vector3Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));
        playedPositions.Add(positionInt);
        Debug.Log("Added position: " + positionInt);
    }

}
