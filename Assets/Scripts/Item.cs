using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Bell, Axe, Food };

    public ItemType itemType;
    public bool inCatRange = false;
    public VRTK.VRTK_InteractableObject interactableObject;
    public Rigidbody rb;
    public AudioSource sound;
    public bool canActivate = true;

    private void Awake()
    {
        // Just in case editor reference bugs out?
        interactableObject = GetComponent<VRTK.VRTK_InteractableObject>();
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        //interactableObject.InteractableObjectGrabbed += OnGrab;
    }

    //private void OnGrab(object sender, VRTK.InteractableObjectEventArgs e)
    //{
    //    velocityEstimate = e.interactingObject.GetComponent<VRTK.VRTK_VelocityEstimator>();
    //}
}
