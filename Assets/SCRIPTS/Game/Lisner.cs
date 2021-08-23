using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lisner : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        if(Player != null)
        transform.position = Player.position + new Vector3(0,4,0);
    }
}
