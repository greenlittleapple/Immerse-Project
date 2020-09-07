using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixEmoteHeight : MonoBehaviour
{
    Transform emote;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(setupChild());
    }

    // Update is called once per frame
    void Update()
    {
        if(emote)
            emote.localPosition = new Vector3(0, 15);
    }

    IEnumerator setupChild()
    {
        while (GetComponentsInChildren<Transform>().Length == 1)
            yield return new WaitForFixedUpdate();
        emote = GetComponentsInChildren<Transform>()[1];
    }
}
