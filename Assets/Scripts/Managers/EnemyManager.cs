using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private List<WaveConfiguration> waves = new List<WaveConfiguration>();
    public static List<IWalkingEnemy> _walkingEnemies = new List<IWalkingEnemy>();
    public static List<IFlyingEnemy> _flyingEnemies = new List<IFlyingEnemy>();
    private void Start()
    {
        StartCoroutine(CreateWave());
        //enemyFactory.CreateFlyingEnemy(EnemyType.Amy);
    }

    public IEnumerator CreateWave()
    {
        foreach (WaveConfiguration wave in waves)
        {
            for(int i=0; i<wave.enemyCount;i++)
            {
                IFlyingEnemy flyingEnemy = enemyFactory.CreateFlyingEnemy(wave.enemyType);
                IWalkingEnemy walkingEnemy = enemyFactory.CreateWalkingEnemy(wave.enemyType);
                
                if (flyingEnemy != null)
                {
                    _flyingEnemies.Add(flyingEnemy);
                }

                if (walkingEnemy != null)
                {
                    _walkingEnemies.Add(walkingEnemy);
                }
                
                yield return new WaitForSeconds(wave.spawnDelay);
            }

            yield return new WaitForSeconds(30f);
        }
    }
    
}
