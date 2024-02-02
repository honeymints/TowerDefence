using System;
using System.Collections.Generic;
using UnityEngine;

namespace Exemple.Factory
{
    public class WaveMeneger : MonoBehaviour
    {
        /// <summary>
        /// List of enemies data and wave settings
        /// </summary>
        [SerializeField] private List<WaveSettings> waveSettings = new List<WaveSettings>();

        /// <summary>
        /// List of enemies
        /// </summary>
        private List<IEnemy> enemies = new List<IEnemy>();

        /// <summary>
        /// Wave settings
        /// </summary>
        [Serializable]
        public class WaveSettings
        {
            public int EnemyCount;
            public float WaveDelay;
            public float CostPerUnit;
            public EnemyData EnemyData;
        }

        private void Start()
        {
            CreateWave(waveSettings[1]);
        }

        /// <summary>
        /// Create wave of enemies
        /// </summary>
        /// <param name="waveData"></param>
        public void CreateWave(List<WaveSettings> waveSettings)
        {
            foreach (WaveSettings data in waveSettings)
            {
                for (int i = 0; i < data.EnemyCount; i++)
                {
                    IEnemy enemy = CreateEnemy(data.EnemyData);
                    enemy.Move();//you can add Vector3 enemy.Move(whereToMove);
                    enemies.Add(enemy);
                }
            }
        }

        /// <summary>
        /// Create one enemy
        /// </summary>
        /// <param name="waveData"></param>
        public void CreateWave(WaveSettings waveSettings)
        {
            for (int i = 0; i < waveSettings.EnemyCount; i++)
            {
                IEnemy enemy = CreateEnemy(waveSettings.EnemyData);
                enemy.Move();//you can add Vector3 enemy.Move(whereToMove);
                enemies.Add(enemy);
            }
        }

        /// <summary>
        /// Get enemy by factory type
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IEnemy CreateEnemy(EnemyData data)
        {
            switch (data.Type)
            {
                case EnemyType.Cube:
                    EnemyFactory<CubeEnemy> cubeFactory = new EnemyFactory<CubeEnemy>();
                    return cubeFactory.CreateEnemy(data);
                case EnemyType.Cylinder:
                    EnemyFactory<CylinderEnemy> cylinderFactory = new EnemyFactory<CylinderEnemy>();
                    return cylinderFactory.CreateEnemy(data);
                default:
                    return null;
            }
        }
    }
}