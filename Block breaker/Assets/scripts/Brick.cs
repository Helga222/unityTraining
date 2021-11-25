using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public AudioClip crack;
    public static int breakableCount=0;
    public Sprite[] hitSprites;
    public GameObject Smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        //keep track of breakable bricks
        if (isBreakable) {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {

		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position,0.8f);
        bool isBreakable = (this.tag == "Breakable");
        if (isBreakable) HandleHits();

    }
    void HandleHits()   {
        timesHit = timesHit + 1;
        int maxHints = hitSprites.Length + 1;
        if (timesHit >= maxHints)   {
            breakableCount--;
            Debug.Log(breakableCount);
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else LoadSprites();
    }

    void PuffSmoke() {
        GameObject smokePuff = Instantiate(Smoke, transform.position, Quaternion.identity);
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else Debug.LogError("Brick sprite missing");
    }
    void SimulateWin() { 
    levelManager.LoadNextLevel();
    }
}
