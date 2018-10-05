using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonController : MonoBehaviour {

    public Color[] colorBank;
    private float speed;

    public void BaloonClicked()
    {
        AddScore();
        DestroyBaloon();
    }
    public void DestroyBaloon()
    {
        GameController.instance.currentBaloonCount--;
        Destroy(gameObject);
    }

    private void Start () {
        InitializeBaloon();
    }	
	// Update is called once per frame
	private void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}
    private void InitializeBaloon()
    {
        transform.position = new Vector3(Random.Range(-2.5f, 2.5f), GameObject.Find("BaloonSpawner").transform.position.y);
        GameController.instance.currentBaloonCount++;
        GetComponent<SpriteRenderer>().color = colorBank[Random.Range(0,colorBank.Length)];
        speed = Random.Range(1f, 2f);
    }
    private void AddScore()
    {
        GameController.instance.AddScore();
    }
   
   }
