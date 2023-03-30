using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRadius : MonoBehaviour
{
    public bool canFollowPlayer = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canFollowPlayer = true;
        }
    }
}
