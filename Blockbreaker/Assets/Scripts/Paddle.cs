using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour 
{
  public bool AutoPlay = false;

  private float _mousePosInBlocks;
  private Ball _ball;

  // Use this for initialization
  void Start () 
  {
    _ball = GameObject.FindObjectOfType<Ball>();
  }
  
  // Update is called once per frame
  void Update ()
  {
    if (!AutoPlay)
      MoveWithMouse();
    else
      MoveWithBall();
  }

  private void MoveWithMouse()
  {
    _mousePosInBlocks = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 16, 1.18f, 14.82f);
    var paddlePos = new Vector3(_mousePosInBlocks, this.transform.position.y, 0f);
    this.transform.position = paddlePos;
  }

  private void MoveWithBall()
  {
    var paddlePos = new Vector3(_ball.transform.position.x, this.transform.position.y, 0f);
    this.transform.position = paddlePos;
  }
}
