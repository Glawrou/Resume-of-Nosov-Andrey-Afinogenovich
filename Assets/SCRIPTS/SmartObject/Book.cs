using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{

    Vector3 startPosition;

    Vector3 startMyRotat;

    public string[] URL;

    private void Start()
    {
        startMyRotat = gameObject.transform.localEulerAngles;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            float yRotate = startMyRotat.y + (startPosition.x - Input.mousePosition.x);

            transform.localRotation = Quaternion.Euler(startMyRotat.x, yRotate, startMyRotat.z);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            startMyRotat = gameObject.transform.localEulerAngles;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var item in URL)
            {
                Application.OpenURL(item);
            }         
        }
    }
}
