using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour 
{
  private LevelManager LevelManager;

  public void Start()
  {
    LevelManager = GameObject.FindObjectOfType<LevelManager>();
  }

  public void OnTriggerEnter2D(Collider2D collider)
  {
    LevelManager.LoadLevel("Lose");
  }

  public void OnCollisionEnter2D(Collision2D collision)
  {
  }
}
