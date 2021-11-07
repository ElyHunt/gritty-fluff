using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCapsuleReporter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        this.GetComponentInParent<DisplayNPC>().checkCollision(collision);
        
    }
}
