using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static int _nextlevelIndex = 1;
    private Enemy[] _enemies;
    private static int _finalLevel = 2;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }

        Debug.Log("You killed all enemies!");

        _nextlevelIndex++;
        if (_nextlevelIndex > _finalLevel)
            _nextlevelIndex = 1;
        string nextLevelName = "Level" + _nextlevelIndex;
        
        SceneManager.LoadScene(nextLevelName);
    }
}
