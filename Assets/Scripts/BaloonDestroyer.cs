using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonDestroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if(collision.GetComponent<BaloonController>() != null)
        {
            collision.GetComponent<BaloonController>().DestroyBaloon();
        }
    }
}
