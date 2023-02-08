using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Vector3 _startpos;

    private void Start()
    {
        _startpos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            transform.position = _startpos;
        }
        else if (other.CompareTag("Finish"))
        {
            Debug.Log("You win");
        }
    }
}
