using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public List<GameObject> objectPool = new List<GameObject>();

    [SerializeField]
    private GameObject objectInexPrefab;

    private void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            var Inex = Instantiate(objectInexPrefab);
            Inex.SetActive(false);
            objectPool.Add(Inex);
        }
    }

    public GameObject GetInex()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeSelf)
            {
                return objectPool[i];
            }
        }

        var Inex = Instantiate(objectInexPrefab);
        Inex.SetActive(false);
        objectPool.Add(Inex);
        return Inex;



        return null;
    }
    public void ReleaseInex(GameObject objectInex)
    {
        objectInex.SetActive(false);
    }
}
