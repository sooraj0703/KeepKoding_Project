using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private static int coinNumber = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinNumber=coinNumber+1;
            Destroy(gameObject);
            UIManager.Instance.UpdateCoinText(coinNumber);
        }
    }
}
