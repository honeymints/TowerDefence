using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exemple.Factory
{
    /// <summary>
    /// Enemy interface
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// Configure enemy by data
        /// </summary>
        /// <param name="data"></param>
        void Configure(EnemyData data);

        /// <summary>
        /// Move enemy
        /// </summary>
        void Move();
    }
}