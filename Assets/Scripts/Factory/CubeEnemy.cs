using Exemple.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exemple.Factory
{
    public class CubeEnemy : Enemy
    {
        public override void Move()
        {
            Debug.Log("CubeEnemy Move");
        }
    }
}