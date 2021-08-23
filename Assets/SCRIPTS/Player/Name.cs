using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviourPunCallbacks
{
    public GameObject MyPlayer;

    public Text NameText;

    private Transform target;

    bool active_name = false;

    private void Start()
    {
        target = GameObject.Find("Main Camera").transform;       
    }

    private void Update()
    {
        transform.LookAt(target);
    }

    private void LateUpdate()
    {
        if (PhotonNetwork.PlayerList.Length > 1 && active_name == false)
        {
            NameText.enabled = true;
            active_name = true;
        }
        else if (PhotonNetwork.PlayerList.Length < 2 && active_name == true) 
        {
            NameText.enabled = false;
            active_name = false;
        }

        //if (PhotonNetwork.PlayerList.Length > 1)
        //{
        //    NameText.enabled = true;
        //    active_name = true;
        //}
        //else if (PhotonNetwork.PlayerList.Length < 2)
        //{
        //    NameText.enabled = false;
        //    active_name = false;
        //}

        NameText.text = photonView.Owner.NickName;
    }
}
