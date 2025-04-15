using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform Player;
    public GameEding GameEding;
    bool isPlayerRange;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerRange)
        {
            Vector3 dirtection = Player.transform.position - transform.position + Vector3.up;
            Ray raycas = new Ray(transform.position, dirtection);

            RaycastHit RaycastHit;

            if (Physics.Raycast(raycas, out RaycastHit))
            {
                if (RaycastHit.collider.transform == Player)
                {
                    GameEding.isCought = true;

                }
            }



        }

    }
}
