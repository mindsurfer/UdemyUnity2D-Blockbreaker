using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
  private Paddle Paddle;
  private Vector3 _paddleToBallVector;
  private bool _hasStarted = false;

  // Use this for initialization
  void Start () 
  {
    Paddle = GameObject.FindObjectOfType<Paddle>();
    _paddleToBallVector = this.transform.position - Paddle.transform.position;
  }
  
  // Update is called once per frame
  void Update () 
  {
    if (!_hasStarted)
    {
      this.transform.position = Paddle.transform.position + _paddleToBallVector;

      if (Input.GetMouseButtonDown(0))
      {
        _hasStarted = true;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
      }
    }
  }

  public void OnCollisionEnter2D(Collision2D collision)
  {
    var tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
    
    if (_hasStarted)
    {
      var audioSource = this.GetComponent<AudioSource>();
      if (collision.collider.tag == "Untagged")
        audioSource.Play();
      GetComponent<Rigidbody2D>().velocity += tweak;
    }
  }

}
