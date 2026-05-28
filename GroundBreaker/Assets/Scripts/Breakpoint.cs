using System;
using UnityEngine;

public class Breakpoint : MonoBehaviour
{
    public float RequiredVelocity;
    public GameObject Barrier;
    private DataStore _store;

    public static bool barrierIsBroken;

    private void Start()
    {
        Barrier = GameObject.Find("Barrier");
        _store = FindFirstObjectByType<DataStore>();
    }

    private void Update()
    {
        // Debug.Log(_store.GetData<float>(PlayerMovement.SPEED_DATA));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_store.GetData<float>(PlayerMovement.SPEED_DATA) >= RequiredVelocity || _store.GetData<float>(PlayerMovement.SPEED_DATA) == RequiredVelocity)
        {
            barrierIsBroken = false;
            Destroy(Barrier);
        }
    }
}
