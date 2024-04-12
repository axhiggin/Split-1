using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    private bool grounded;

    public bool isGrounded()
    {
        return grounded;
    }

    private void OnTriggerStay(Collider other)
    {
        grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
}
