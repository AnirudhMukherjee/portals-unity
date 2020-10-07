using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour
{
    public CharacterController player;
    public Transform receiver;

    private bool playerIsOverlapping = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProd = Vector3.Dot(transform.up,portalToPlayer);
            if( dotProd < 0f)
            {
                float rotDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
                rotDiff += 180;
                player.transform.Rotate(Vector3.up, rotDiff);
                Vector3 posOffset = Quaternion.Euler(0f, rotDiff, 0f) * portalToPlayer;
                player.enabled = false;
                player.transform.position = receiver.position + posOffset;
                player.enabled = true;
                playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false ;
        }
    }
}
