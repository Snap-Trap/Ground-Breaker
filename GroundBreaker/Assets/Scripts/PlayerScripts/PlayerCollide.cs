using System.Collections;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    public float stunDuration = 1.5f;
    public float raycastDistance = 1.5f;

    public bool CanMove = true;

    private LayerMask objectLayer;

    public void Awake()
    {
        objectLayer = LayerMask.GetMask("objectLayer");
    }

    public void Update()
    {
        var hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, objectLayer);
        var hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, objectLayer);
        
        if (hitLeft.collider || hitRight.collider)
        {
            StartCoroutine(StunPlayer());
        }
    }

    private IEnumerator StunPlayer()
    {
        CanMove = false;
        Debug.Log("Stunned");
        yield return new WaitForSeconds(stunDuration);
        CanMove = true;
        Debug.Log("Move it move it");
    }
}
