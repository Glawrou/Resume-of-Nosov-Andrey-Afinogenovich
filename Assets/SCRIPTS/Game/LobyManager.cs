using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LobyManager : MonoBehaviourPunCallbacks
{
    public Console Console;

    private GameObject MyPlayer;

    public GameObject PlayerPrifab;

    public Actor MyActor;

    void Start()
    {
        MyActor = JsonUtility.FromJson<Actor>(File.ReadAllText(Application.streamingAssetsPath + "/MyActor.json"));

        try
        {
            if (MyActor.NameNrtvork != null)
            {
                PhotonNetwork.NickName = MyActor.NameNrtvork;
            }
            else
            {
                PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
                Log("Player's name is set to " + PhotonNetwork.NickName);
            }
        }
        catch (System.Exception)
        {

            PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
            Log("Player's name is set to " + PhotonNetwork.NickName);

        }
        

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();

    }

    public void SetNickName(string name)
    {
        PhotonNetwork.NickName = name;
        Log("Player's name is set to " + PhotonNetwork.NickName);
        MyActor.NameNrtvork = name;
        File.WriteAllText(Application.streamingAssetsPath + "/MyActor.json", JsonUtility.ToJson(MyActor));
        MyPlayer.name = PhotonNetwork.NickName;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //Кто то зашел в комнату
        Log(newPlayer.NickName + " entered room");

    }

    public string GetPlayerList()
    {
        string _list = "\n Players in room : " + PhotonNetwork.PlayerList.Length + " " + PhotonNetwork.PlayerList.Length + "\n";

        foreach (var item in PhotonNetwork.PlayerList)
        {
            _list += " [" + item.ActorNumber + "] : " + item.NickName + "\n";
        }

        return _list;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //Кто то покинул комнату
        Log(otherPlayer.NickName + " left room");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }

    public override void OnConnectedToMaster()
    {
        Log("Connect to master");
        JoinRoom();
    }

    public void CriateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 5 });
        Log("Criate new Room");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        Log("Connecting to Room");
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        GameObject player = PhotonNetwork.Instantiate(PlayerPrifab.name, new Vector3(6.56f, 4.94f, 20.83f), Quaternion.identity);
        player.name = PhotonNetwork.NickName;

        MyPlayer = player;
        Console.SetMyPlayer(MyPlayer);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Log("Failed connect to Room");
        CriateRoom();
    }

    private void Log(string masadge)
    {
        Console.Log(masadge);
    }

    [System.Serializable]
    public class Actor
    {
        public string NameNrtvork;   
    }

}
