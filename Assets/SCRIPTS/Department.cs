using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Department : MonoBehaviour
{
    public Text MyCanvas;

    public PlayerController PC;

    public GameObject Book;

    private bool Trigered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(MyCanvas != null)
            MyCanvas.enabled = true;
        Trigered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (MyCanvas != null)
            MyCanvas.enabled = false;
        Trigered = false;
    }

    private void Update()
    {
        if(Trigered)
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Book.active == false)
            {
                    Book.SetActive(true); PC.SetActivityMuvment(false);
            }             
            else
            {
                    Book.SetActive(false); PC.SetActivityMuvment(true);
            }
                    
        }
    }
}
