using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] ArkanoidUI arkanoidUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        arkanoidUI.blocksInGame--;
        Destroy(gameObject);
    }
}
