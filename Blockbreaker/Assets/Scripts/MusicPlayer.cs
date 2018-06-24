using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
  private static MusicPlayer _instance = null;

  void Awake()
  {
    if (_instance != null)
    {
      Destroy(gameObject);
      print("Duplicate music player self-destructing!");
    }
    else
    {
      _instance = this;
      GameObject.DontDestroyOnLoad(gameObject);
    }
  }

  // Use this for initialization
  void Start () 
  {
  } 
  
  // Update is called once per frame
  void Update () 
  {
    
  }
}
