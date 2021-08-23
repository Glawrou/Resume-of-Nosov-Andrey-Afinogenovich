using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviourPun, IPunObservable
{
    public PlayerController MyPlayer;

    public MakingSounds MakingSounds;

    private Department _departament;

    public GameObject MyDrum;

    public bool Drum = false;

    bool triger_departament = false;
    bool triger_GoldBox = false;
    bool triger_Drum = false;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Drum);
        }
        else
        {
            Drum = (bool)stream.ReceiveNext();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.tag == "Department")
            {
                triger_departament = true;
                _departament = other.gameObject.GetComponent<Department>();
            }

            if (other.tag == "GoldBox")
            {
                triger_GoldBox = true;
                _departament = other.gameObject.GetComponent<Department>();
            }

            if (other.tag == "Drum")
            {
                triger_Drum = true;
                _departament = other.gameObject.GetComponent<Department>();
            }
        }
    }

    public bool GetDrum()
    {
       return Drum;
    }

    public void SetDrum(bool b)
    {
        Drum = b;
        //MyDrum.SetActive(b);
    }

    private void OnTriggerExit(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.tag == "Department")
            {
                triger_departament = false;
            }

            if (other.tag == "GoldBox")
            {
                triger_GoldBox = false;
            }

            if (other.tag == "Drum")
            {
                triger_Drum = false;
            }
        }
    }

    private void Update()
    {

        if (!photonView.IsMine)
        {
            MyDrum.SetActive(Drum);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && triger_departament == true && MyPlayer.GetActivityMuvment() == true)
            {
                MyPlayer.SetActivityMuvment(false);
                MakingSounds.PlayBookOpen();
                _departament.Book.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && triger_departament == true && MyPlayer.GetActivityMuvment() == false)
            {
                MyPlayer.SetActivityMuvment(true);
                MakingSounds.PlayBookClose();
                _departament.Book.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E) && triger_GoldBox == true && MyPlayer.GetActivityMuvment() == true)
            {
                MyPlayer.SetActivityMuvment(false);

                _departament.Book.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && triger_GoldBox == true && MyPlayer.GetActivityMuvment() == false)
            {
                MyPlayer.SetActivityMuvment(true);
                MakingSounds.PlayCoinDrop();
                _departament.Book.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E) && triger_Drum == true && Drum == false)
            {
                MyPlayer.SetActivityMuvment(false);
                _departament.Book.SetActive(true);
                SetDrum(true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && triger_Drum == true)
            {
                MyPlayer.SetActivityMuvment(true);
                _departament.Book.SetActive(false);
                SetDrum(false);
            }
        }
     
    }

   
}
