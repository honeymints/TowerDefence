using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private List<WaveConfiguration> waves = new List<WaveConfiguration>();
    
    public static List<IWalkingEnemy> _walkingEnemies = new List<IWalkingEnemy>();
    public static List<IFlyingEnemy> _flyingEnemies = new List<IFlyingEnemy>();

    public static EnemyType enemyType;

    private void Start()
    {
        StartCoroutine(CreateWave());
    }

    public IEnumerator CreateWave()
    {
        foreach (WaveConfiguration wave in waves)
        {
            yield return StartCoroutine(CreateEnemies(wave));
            
            yield return new WaitUntil(CheckIfEnemiesDead);
        }
    }

    public IEnumerator CreateEnemies(WaveConfiguration wave)
    {
        for(int i=0; i<wave.enemyCount;i++)
        {
            IFlyingEnemy flyingEnemy = enemyFactory.CreateFlyingEnemy(wave.enemyType);
            IWalkingEnemy walkingEnemy = enemyFactory.CreateWalkingEnemy(wave.enemyType);

            if (flyingEnemy != null) _flyingEnemies.Add(flyingEnemy);

            if (walkingEnemy != null) _walkingEnemies.Add(walkingEnemy);
            
            enemyType = wave.enemyType;

            yield return new WaitForSeconds(wave.spawnDelay);
        }
    }

    public bool CheckIfEnemiesDead()
    {
        if (_walkingEnemies.Count <= 0 && _flyingEnemies.Count<=0)
        {
            return true;
        }

        return false;
    }
}
