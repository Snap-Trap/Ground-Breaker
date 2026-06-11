using System.Threading;
using UnityEngine;

public class PlayerBarrierCheck : MonoBehaviour
{
    private LayerMask barrierLayer;
    private DataStore _store;


    public float RequiredVelocity;
    public float raycastDistance;

    public GameObject Barrier;

    public static bool barrierIsBroken;
    public static bool barrierIsHit;

    public void Start()
    {
        barrierLayer = LayerMask.GetMask("barrierLayer");
        Barrier = GameObject.Find("Barrier");

        _store = FindFirstObjectByType<DataStore>();
    }
    public void Update()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, barrierLayer);

        if (hit.collider)
        {
            Debug.Log("Player hit the barrier");
            barrierIsHit = true;
        }
        else
        {
            Debug.Log("Player is not hitting ANYTHING at all, scrub");
        }

        if (barrierIsHit == true)
        {
            float playerSpeed = _store.GetData<float>(PlayerMovement.SPEED_DATA);

            if (playerSpeed >= RequiredVelocity || playerSpeed == RequiredVelocity)
            {
                Debug.Log("The player had enough speed, it was: " + playerSpeed);
                barrierIsBroken = true;
                Destroy(Barrier);
            }
            else
            {
                Debug.Log("Unfortunately, the player did not reach the speed treshold" + playerSpeed);
            }
        }
    } 
}

