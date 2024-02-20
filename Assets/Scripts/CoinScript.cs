using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public ParticleSystem coinPS;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().coins++;
            other.GetComponent<PlayerController>().coinsCollectedSinceLastMultiply++;
            Instantiate(coinPS, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
