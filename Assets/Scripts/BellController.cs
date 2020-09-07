using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : Item
{
    private void Update()
    {
        if (interactableObject.IsGrabbed())
            if (rb.velocity.magnitude >= 8)
            {
                GameManager.ins.cat.ReactToItem(this);
                sound.Play();
            }
    }
}
