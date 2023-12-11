using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PieceData
{
    public string pieceType;
    public string pieceColor;
    public int health;
    public int attack;
    // Add more stats as needed
}

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public PieceData takerPiece;
    public PieceData takenPiece;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetCombatData(PieceData taker, PieceData taken)
    {
        takerPiece = taker;
        takenPiece = taken;
    }
}