using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PoolShooting : MonoBehaviour
{
    public Pooling pooling;

    public void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var Inex = pooling.GetInex();
            Inex.SetActive(true);
            Inex.transform.position = transform.position;


            var rb = Inex.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.right * 500);

            StartCoroutine(ReturnInex(Inex));
        }
    }

    IEnumerator ReturnInex(GameObject Inex)
    {
        yield return new WaitForSeconds(3f);
        pooling.ReleaseInex(Inex);
    }
}
