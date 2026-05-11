using System.Collections.Generic;
using UnityEngine;

public class Dictionaries : MonoBehaviour
{
    public Dictionary <int, int> numbersCounter = new Dictionary<int, int>();
    public void Update()
    {
        for (int i = 0; i < 100000; i++)
        {
           int randomNumber = Random.Range(5, 16);

            if (numbersCounter.ContainsKey(randomNumber))
            {
                numbersCounter[randomNumber]++;

                foreach (KeyValuePair<int, int> entry in numbersCounter)
                {
                    Debug.Log("Number: " + entry.Key + ", Count: " + entry.Value);
                }
            }
            else
            {
                numbersCounter.Add(randomNumber, 1);
            }
        }
    }
}
