using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Player player;

    private List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        UIManager.Instance.UpdateEnemyCount(enemies.Count);
    }

    public void AddEnemyToList(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemyFromList(Enemy enemy)
    {
        enemies.Remove(enemy);
        UIManager.Instance.UpdateEnemyCount(enemies.Count);
        CheckEnemies();
    }

    public void PlayerDead()
    {
        Debug.LogWarning("Player is dead. Reloading Scene...");
        SceneManager.LoadScene(0);
    }

    public void CheckEnemies()
    {
        if (enemies.Count == 0)
        {
            Debug.LogWarning("No enemies left. Reloading Scene...");
            SceneManager.LoadScene(0);
        }
    }
}
