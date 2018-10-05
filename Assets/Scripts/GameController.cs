using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int maxBalloonCount;
    public int currentBaloonCount;
    public GameObject balloon;
    public GameObject popUpMessage;
    public Text popUpMessageText;
    public Text scoreText;

    private int score;
    private bool spawning;
    private bool balloonClicking;
    //private int menuType; // 0 - "Playing", 1 - "Menu", 2 - "Settings"


    public static GameController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        popUpMessage.SetActive(false);
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        spawning = false;
        balloonClicking = true;
        Spawn();   
	}


    // Update is called once per frame
    void Update() {
        if (currentBaloonCount < maxBalloonCount && !spawning)
        {
            Spawn();
        }
        if (Input.GetMouseButtonDown(0) && balloonClicking)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Camera.main.transform.forward,10f);
            if (hit)
            {
                if (hit.collider.name == "Balloon(Clone)")
                {
                    hit.collider.gameObject.GetComponent<BaloonController>().BaloonClicked();
                }
            }
            
        }
            
    }
        public void Spawn()
    {
        if (!spawning)
        {
            StartCoroutine("SpawnBalloon");
        }
        
    }
    public void AddScore()
    {
        score ++ ;
        scoreText.text = "Score: " + score.ToString();
    }
    public void OpenMenu(int menuType)
    {
        switch (menuType)
        {
            case (0):
                balloonClicking = true;
                popUpMessage.SetActive(false);
                Time.timeScale = 1;
                break;
            case (1):
                balloonClicking = false;
                popUpMessage.SetActive(true);
                popUpMessageText.text = "MENU";
                Time.timeScale = 0;

                break;
            case (2):
                balloonClicking = false;
                popUpMessage.SetActive(true);
                popUpMessageText.text = "Settings";
                Time.timeScale = 0;
                break;
            

        }
    }
    IEnumerator SpawnBalloon()
    {
        spawning = !spawning;
        for (;currentBaloonCount<maxBalloonCount;)
        {
            Instantiate(balloon);
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
        yield return null;
        spawning = !spawning;
    }
}
