using System.Collections;
using UnityEngine;

public class CameraIntroFollow : MonoBehaviour
{
    public Transform player;
    public float introStartY;
    public float introSpeed = 2f;
    public float followSpeed = 5f;
    
    public float followOffsetY = 0.5f;

    private bool introDone;

    private PlayerMovement playerMovement;

    public void Start()
    {
        Vector3 pos = transform.position;
        pos.y = introStartY;
        transform.position = pos;

        playerMovement = player.GetComponent<PlayerMovement>();

        StartCoroutine(IntroSequence());
    }

    public IEnumerator IntroSequence()
    {
        // Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(transform.position.x, player.position.y + followOffsetY, transform.position.z);
        
        // Vector3 endPos = new  Vector3(startPos.x, player.position.y, startPos.z);
        while (Vector3.Distance(transform.position, endPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, introSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = endPos;

        introDone = true;

        if (playerMovement == null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }

        if (playerMovement != null)
        {
            playerMovement.canMove = true;
            Debug.Log("Player movement enabled");
        }
    }

    public void LateUpdate()
    {
        if (!introDone || player == null) return;

        Vector3 target = new Vector3(transform.position.x, player.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * followSpeed);
    }
}
