using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exemple.Factory
{
    /// <summary>
    /// Enemy types
    /// </summary>
    public enum EnemyType
    {
        Cube,
        Cylinder
    }

    /// <summary>
    /// Enemy data
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        public GameObject Prefab;
        public EnemyType Type;
        public float MoveSpeed;
        public float Health;        
    }   
}