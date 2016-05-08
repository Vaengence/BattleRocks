using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

public class GameManager2 : MonoBehaviour
{

    public static GameManager2 GameMaster;

    string GameDataFile = "GameData\\GameData.txt";

    public struct GameDataStruct
    {
        public string PlayerName;
        public int CurrentLives;
        public int CashCurrency;
    };

    public enum GameDataEnum
    {
        PLAYER_NAME = 0,
        CURRENT_LIVES = 1,
        CASH_CURRENCY = 2
    };

    GameDataStruct GameData = new GameDataStruct();

    // Use this for initialization
    void Awake()
    {
        if (GameManager2.GameMaster == null)
        {
            DontDestroyOnLoad(gameObject);
            GameManager2.GameMaster = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGameData()
    {
        using (StreamWriter WriteGameData = new StreamWriter(GameDataFile, false))
        {
            for (int i = 0; i < Enum.GetNames(typeof(GameDataEnum)).Length; i++)
            {
                WriteGameData.Write(i);
                WriteGameData.Write(',');

                switch (i)
                {
                    case (int)GameDataEnum.PLAYER_NAME:
                        WriteGameData.Write(GameData.PlayerName);
                        break;
                    case (int)GameDataEnum.CURRENT_LIVES:
                        WriteGameData.Write(GameData.CurrentLives);
                        break;
                    case (int)GameDataEnum.CASH_CURRENCY:
                        WriteGameData.Write(GameData.CashCurrency);
                        break;
                    default:
                        break;
                }

                WriteGameData.Write(Environment.NewLine);
            }
        }

    }

    public void LoadGameData()
    {
        if (!File.Exists(GameDataFile))
        {
            return;
        }

        string ReadLine;
        StreamReader ReadGameData = new StreamReader(GameDataFile, Encoding.Default);

        using (ReadGameData)
        {
            ReadLine = ReadGameData.ReadLine();

            if (ReadLine != null)
            {
                string[] DataTempArray = ReadLine.Split(',');

                do {
                    switch (Int32.Parse(DataTempArray[0])) // Position 0 in the array will always be the enum type being stored on a line
                    {
                        case (int)GameDataEnum.PLAYER_NAME:
                            GameData.PlayerName = DataTempArray[1];
                            break;

                        case (int)GameDataEnum.CURRENT_LIVES:
                            GameData.CurrentLives = Int32.Parse(DataTempArray[1]);
                            break;

                        case (int)GameDataEnum.CASH_CURRENCY:
                            GameData.CashCurrency = Int32.Parse(DataTempArray[1]);
                            break;

                        default:
                            break;
                    }
                } while (ReadLine != null);
            }
        }
    }
}