using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {
    public bool autoPlay = false;
    private ball ball;
    public float MinPosX, MaxPosX;
 

	void Start(){
        ball = GameObject.FindObjectOfType<ball>();
    }
	// Update is called once per frame
	void Update () {
         if (!autoPlay) MoveWithMouse();
        else AutoPlay();
    }
    void AutoPlay() {
        Vector3 ballPos = ball.transform.position;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(ballPos.x, MinPosX, MaxPosX);
        this.transform.position = paddlePos;
    }
    void MoveWithMouse()    {
        float mousePosInBlocks;
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, MinPosX, MaxPosX);
        this.transform.position = paddlePos;
    }
}
