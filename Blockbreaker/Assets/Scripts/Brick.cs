using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour 
{
  public Sprite[] HitSprites;
  public AudioClip Crack;
  public GameObject Smoke;

  public static int BreakableCount = 0;

  private int _hitCount;
  private LevelManager _levelManager;
  private bool _isBreakable;

  // Use this for initialization
  void Start () 
  {
    _isBreakable = this.tag == "Breakable";
    if (_isBreakable)
    { 
      BreakableCount++;
    }
    _levelManager = GameObject.FindObjectOfType<LevelManager>();
    _hitCount = 0;
  }
  
  // Update is called once per frame
  void Update () 
  {
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    AudioSource.PlayClipAtPoint(Crack, this.transform.position);
    if (_isBreakable)
      HandleHits();
  }

  private void HandleHits()
  {
    _hitCount++;
    var maxHits = HitSprites.Length + 1;
    if (_hitCount >= maxHits)
    {
      BreakableCount--;
      _levelManager.BrickDestroyed();
      CreateSmokePuff();
      Destroy(gameObject);
    }
    else
      LoadSprites();
  }

  private void CreateSmokePuff()
  {
    var smokePuff = Instantiate(Smoke, this.transform.position, Quaternion.identity);
    var particleSystem = smokePuff.GetComponent<ParticleSystem>().main;
    particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
  }

  private void LoadSprites()
  {
    var spriteIndex = _hitCount - 1;
    if (HitSprites[spriteIndex])
      this.GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
  }

  private void SimulateWin()
  {
    _levelManager.LoadNextLevel();
  }
}
