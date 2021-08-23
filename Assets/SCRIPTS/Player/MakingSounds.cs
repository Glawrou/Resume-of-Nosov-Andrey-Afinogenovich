using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MakingSounds : MonoBehaviourPun, IPunObservable
{

    public AudioClip[] StepAudio;
    public AudioClip[] BookOpenAndClose;
    public AudioClip CoinDrop;
    public AudioClip[] Drum;
    public AudioSource MyAudioSurse;

    //Клип для проигрывания
    int NuberClip = 0;

    //Последний отправленый клип
    int lastNuberClip = 0;

    //Ходьба
    bool PlayingStep = false;

    bool isSend = false;
    

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if(isSend == true)
            {
                stream.SendNext(NuberClip);
                isSend = false;
            }
            else
            {
                stream.SendNext(0);
            }
          
        }
        else
        {
            NuberClip = (int)stream.ReceiveNext();
        }
    }

    private void Update()
    {
        if(!photonView.IsMine)
        if(NuberClip != 0)
        {
            MyAudioSurse.PlayOneShot(GetAudioClipNumber(NuberClip));
            NuberClip = 0;
        }
    }

    public void PlayDrumOne()
    {
        SetNumberAudioClip(Drum[0]);
        isSend = true;
    }
    public void PlayDrumTwo()
    {
        SetNumberAudioClip(Drum[1]);
        isSend = true;
    }

    public void PlayDrumTree()
    {
        SetNumberAudioClip(Drum[2]);
        isSend = true;
    }

    public IEnumerator PlayStep()
    {
        if (PlayingStep == false)
        {
            PlayingStep = true;

            int R = Random.Range(0, StepAudio.Length);

            SetNumberAudioClip(StepAudio[R]);
            isSend = true;
            yield return new WaitForSeconds(0.3f);
            PlayingStep = false;
        }
    }


    [ContextMenu("PlayBOokOpen")]
    public void PlayBookOpen()
    {
        SetNumberAudioClip(BookOpenAndClose[0]);
        isSend = true;
    }


    public void PlayBookClose()
    {
        SetNumberAudioClip(BookOpenAndClose[1]);
        isSend = true;
    }

    public void PlayCoinDrop()
    {
        SetNumberAudioClip(CoinDrop);
        isSend = true;
    }

    public void SetNumberAudioClip(AudioClip _clip)
    {

        MyAudioSurse.PlayOneShot(_clip);

        int number = 0;

        int counter = 0;

        foreach (var item in StepAudio)
        {
            counter++;
            if(item == _clip)
            {
                number = counter;
            }
        }

        foreach (var item in BookOpenAndClose)
        {
            counter++;
            if (item == _clip)
            {
                number = counter;
            }
        }

        counter++;
        if (CoinDrop == _clip)
        {
            number = counter;
        }

        foreach (var item in Drum)
        {
            counter++;
            if (item == _clip)
            {
                number = counter;
            }
        }

        NuberClip = number;

    }

    public AudioClip GetAudioClipNumber(int numberClip)
    {
        AudioClip _Clip = null;

        int counter = 0;

        foreach (var item in StepAudio)
        {
            counter++;
            if(numberClip == counter)
            {
                _Clip = item;
            }
        }

        foreach (var item in BookOpenAndClose)
        {
            counter++;
            if (numberClip == counter)
            {
                _Clip = item;
            }
        }

        counter++;
        if (numberClip == counter)
        {
            _Clip = CoinDrop;
        }

        foreach (var item in Drum)
        {
            counter++;
            if (numberClip == counter)
            {
                _Clip = item;
            }
        }

        return _Clip;
    }
}
