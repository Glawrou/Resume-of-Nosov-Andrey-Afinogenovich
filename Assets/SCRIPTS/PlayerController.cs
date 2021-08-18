using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public Animator Anim;

    public CharacterController CC;

    public float Speed = 12f;

    public float gravity = -9.81f;

    Vector3 velosity;

    bool _activity = true;

    public GameObject[] helper;

    void Update()
    {
        movment();
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetActivityMuvment(bool activity)
    {
        _activity = activity;
    }

    private void movment()
    {
        if (_activity)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 Rot = new Vector3(x, 0, z) + new Vector3(transform.position.x, transform.position.y, transform.position.z);

            transform.LookAt(Rot);

            Vector3 Movement = Vector3.right * x + Vector3.forward * z;

            CC.Move(Movement * Speed * Time.deltaTime);

            velosity.y += gravity * Time.deltaTime;

            CC.Move(velosity * Time.deltaTime);

            if (x != 0 || z != 0)
            {
                Anim.SetBool("Walk", true);

                foreach (var item in helper)
                {
                    item.SetActive(false);
                }
            }
            else
            {
                Anim.SetBool("Walk", false);
            }
        }
    }
}
