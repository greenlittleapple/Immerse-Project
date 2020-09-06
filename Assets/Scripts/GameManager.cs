using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public CatController cat;
    public VRTK.VRTK_DestinationPoint treeTeleportPoint;

    private void Awake()
    {
        // Singleton stuff
        if (ins)
            Destroy(gameObject);
        ins = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupObjects());
    }

    IEnumerator SetupObjects()
    {
        // Reference doesn't get set until after game starts, so we need to wait
        while (!treeTeleportPoint.teleporter)
            yield return new WaitForFixedUpdate();
        // Make things happen when someone teleports to the tree point
        treeTeleportPoint.teleporter.Teleported += OnTreeTeleport;
    }

    private void OnTreeTeleport(object sender, VRTK.DestinationMarkerEventArgs e)
    {
        if(e.target == treeTeleportPoint.transform)
            // Make the cat responsive to items
            cat.EnableReaction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
