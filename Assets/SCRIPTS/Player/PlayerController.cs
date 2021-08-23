using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PhotonView photonView;

    private Inventary MyInventary;

    private CameraFolow MyCamera; 

    public Animator Anim;

    public CharacterController CC;

    public float Speed = 12f;

    public float gravity = -9.81f;

    public MakingSounds MyMakingSoud;

    Vector3 velosity;

    bool _activity = true;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        ResetCamera();
        MyInventary = GetComponent<Inventary>();
    }

    public void ResetCamera()
    {
        GameObject Camera = GameObject.Find("Main Camera");
        Camera.GetComponent<CameraFolow>().target = GameObject.Find(gameObject.name).transform;
        MyCamera = Camera.GetComponent<CameraFolow>();

        //Ресет слушателя
        GameObject.Find("Lisner").GetComponent<Lisner>().Player = GameObject.Find(gameObject.name).transform;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            movment();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }     
    }

    public void SetActivityMuvment(bool activity)
    {
        _activity = activity;
    }

    public bool GetActivityMuvment()
    {
        return _activity;
    }

    private void movment()
    {

        if(true)
        {
            //if (Input.GetKeyDown(KeyCode.J))
            //{
            //    Anim.SetTrigger("Hit");
            //}

            if(MyInventary.GetDrum() == true)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    MyMakingSoud.PlayDrumOne();
                    Anim.SetTrigger("Hit");
                }
                else if (Input.GetKeyDown(KeyCode.K))
                {
                    MyMakingSoud.PlayDrumTwo();
                    Anim.SetTrigger("Hit");
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    MyMakingSoud.PlayDrumTree();
                    Anim.SetTrigger("Hit");
                }
            }           
        }

        //Перемещение
        if (_activity)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Anim.SetFloat("Walk", System.Math.Abs(x) + System.Math.Abs(z));

            Vector3 Rot = new Vector3(x, 0, z) + new Vector3(transform.position.x, transform.position.y, transform.position.z);

            transform.LookAt(Rot);

            Vector3 Movement = Vector3.right * x + Vector3.forward * z;

            if (x != 0 && z != 0)
                Movement = Movement * 0.8f;

            CC.Move(Movement * Speed * Time.deltaTime);

            velosity.y += gravity * Time.deltaTime;

            CC.Move(velosity * Time.deltaTime);

            if (x != 0 || z != 0)
            {
                StartCoroutine(MyMakingSoud.PlayStep());
                Anim.SetBool("Sit", false);
                MyCamera.SetActiveHelper(false);
            }
        }
        else
        {
            Anim.SetFloat("Walk", 0);
        }

    }
}
