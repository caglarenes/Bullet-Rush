using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Text enemyCountText;

    public void UpdateEnemyCount(int enemyCount)
    {
        enemyCountText.text = enemyCount.ToString();
    }
}
