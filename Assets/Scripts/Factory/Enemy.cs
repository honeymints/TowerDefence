using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exemple.Factory
{
    /// <summary>
    /// Enemy abstract class
    /// </summary>
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] protected EnemyData data;

        /// <summary>
        /// Configure enemy by data
        /// </summary>
        /// <param name="data"></param>
        public virtual void Configure(EnemyData data)
        {
            this.data = data;
        }

        public abstract void Move();
    }
}