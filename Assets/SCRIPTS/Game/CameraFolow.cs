using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraFolow : MonoBehaviour
{
    public Transform target;

    public Vector3 Ofset;

    public GameObject[] Helper;

    private Camera MyCamera;

    private void Start()
    {
        MyCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            //MyCamera.targetDisplay = Display.main.;
            Debug.Log(Display.main.systemHeight);
        }

        if (target != null)
        {
            transform.LookAt(target);

            transform.position = target.position + Ofset;
        }      
    }

    public GameObject[] GetHelper()
    {
        return Helper;
    }

    public void SetActiveHelper(bool _active)
    {
        foreach (var item in Helper)
        {
            item.SetActive(_active);
        }
    }
}
