using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public AudioSource audioSource;
    bool canMeow, randomMeow, canReactToPlayer;
    public SphereCollider reactRange;

    // Start is called before the first frame update
    void Start()
    {
        canMeow = true;
        randomMeow = true;
        canReactToPlayer = false;
    }

    public void EnableReaction()
    {
        // Stop random meowing and make it reactable
        randomMeow = false;
        canReactToPlayer = true;
        reactRange.enabled = true;
    }

    public void ReactToItem(Item item)
    {
        if(item.inCatRange && canReactToPlayer)
        {
            canMeow = true;
            TryMeow();
            canReactToPlayer = false;
        }
    }

    public void ResetBehavior()
    {
        canMeow = randomMeow = true;
        canReactToPlayer = false;
        reactRange.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(randomMeow)
            StartCoroutine(TryMeow());
    }

    IEnumerator TryMeow()
    {
        if(canMeow)
        {
            canMeow = false;
            audioSource.Play();
            yield return new WaitForSeconds(Random.Range(5, 10));
            canMeow = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        Item x = other.GetComponent<Item>();
        if (x)
            x.inCatRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Item x = other.GetComponent<Item>();
        if (x)
            x.inCatRange = false;
    }
}
