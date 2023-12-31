using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatSceneController : MonoBehaviour
{
    public GameObject piecePrefabParent; // Assign a parent GameObject in the inspector for organization

    void Start()
    {
        InstantiatePiece(GameData.instance.takerPiece, true);
        InstantiatePiece(GameData.instance.takenPiece, false);
    }

    void InstantiatePiece(PieceData pieceData, bool isTaker)
    {
        // Load the prefab based on pieceType
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/ChessPieces/{pieceData.pieceType}");

        if (prefab != null)
        {
            GameObject pieceInstance = Instantiate(prefab, GetSpawnPosition(isTaker), Quaternion.identity, piecePrefabParent.transform);

            // Scale the taken piece
            if (!isTaker)
            {
                pieceInstance.transform.localScale = new Vector3(15, 15, 15);
            }

            // Additional setup for your piece can be done here
        }
        else
        {
            Debug.LogError($"Prefab not found for type: {pieceData.pieceType}");
        }
    }

    Vector3 GetSpawnPosition(bool isTaker)
    {
        // Spawn the taker at (0, 0, 0) and the taken at (0, 0, 20)
        return isTaker ? new Vector3(0, 0, 0) : new Vector3(0, 0, 20);
    }

    public void EndCombat()
    {
        if (takenPieceInstance != null)
        {
            // Revert scale to original (assuming original scale is 1, 1, 1)
            takenPieceInstance.transform.localScale = new Vector3(1, 1, 1);
        }

    }
}