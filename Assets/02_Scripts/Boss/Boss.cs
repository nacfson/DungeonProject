using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Enemy enemy;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    public UnityEvent GameClear;
    private void Update() {
        if(enemy.hp <=0)
        {
            GameClear?.Invoke();
        }

    }
    public void LoadSceneGameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
