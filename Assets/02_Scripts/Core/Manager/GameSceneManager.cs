using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : SceneManagerParent
{
    public void GameOver()
    {
        base.LoadScene("GameOver");
    }
}
