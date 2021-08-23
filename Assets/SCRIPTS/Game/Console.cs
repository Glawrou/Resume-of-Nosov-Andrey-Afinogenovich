using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public GameObject MyPlayer;

    public InputField InputFeidConsole;

    public LobyManager LobyManager;

    public Text LogText;

    string String_Console;

    public void InputConsole()
    {
        if(TeamCheck(InputFeidConsole.text) == false)
        {
            Log(InputFeidConsole.text);
            InputFeidConsole.text = "";
        }     
    }

    public bool TeamCheck(string command)
    {
        bool is_comand = false;
        string test_command = "";

        bool SetNickname = false;
        bool GetPlayersList = false;

        foreach (var item in command)
        {
            test_command += item;

            if (SetNickname == false)
            {
                switch (test_command)
                {
                    case "set my name ":
                        test_command = "";
                        SetNickname = true;
                        break;
                    case "get players list":
                        test_command = "";
                        GetPlayersList = true;
                        break;
                    default:
                        break;
                }
            }
            
        }

        if (GetPlayersList == true)
        {
            is_comand = true;
            Log(LobyManager.GetPlayerList());
            InputFeidConsole.text = "";
        }

        if (SetNickname == true)
        {
            is_comand = true;
            LobyManager.SetNickName(test_command);
            InputFeidConsole.text = "";
        }

        return is_comand;
    }

    public void Log(string massage)
    {
        String_Console += massage + "\n";

        LogText.text = String_Console;
    }

    public void SetMyPlayer(GameObject Player)
    {
        MyPlayer = Player.transform.Find("Andrey").gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            switch (LogText.enabled)
            {
                case false:
                    LogText.enabled = true;
                    InputFeidConsole.gameObject.SetActive(true);
                    break;
                case true:
                    LogText.enabled = false;
                    InputFeidConsole.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}
