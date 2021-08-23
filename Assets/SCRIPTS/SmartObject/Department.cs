using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Department : MonoBehaviour
{
    public Text MyCanvas;

    public GameObject Book;

    private bool Trigered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (MyCanvas != null)
            MyCanvas.enabled = true;

        Trigered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (MyCanvas != null)
            MyCanvas.enabled = false;
        Trigered = false;
    }

}
