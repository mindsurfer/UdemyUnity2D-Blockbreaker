using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
  public void LoadLevel(string name)
  {
    print("Level load requested for: " + name);
    Brick.BreakableCount = 0;
    SceneManager.LoadScene(name); 
  }

  public void QuitRequest()
  {
    print("Quit request sent");
    Application.Quit();
  }

  public void LoadNextLevel()
  {
    Brick.BreakableCount = 0;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void BrickDestroyed()
  {
    if (Brick.BreakableCount <= 0)
      LoadNextLevel();
  }
}
