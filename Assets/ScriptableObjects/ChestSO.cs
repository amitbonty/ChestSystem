using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ChestSystem
{
    [CreateAssetMenu(fileName = "ChestSO", menuName = "ScriptableObjects/ChestScriptableObject", order = 6)]
    public class ChestSO : ScriptableObject
    {
        public int _maxCoinsRequired;
        public int _minCoinsRequired;
        public int _minGemsRequired;
        public int _maxGemsRequired;
        public int _coinsGained;
        public int _GemsGained;
        public ChestTypes _chestType;
        public float unlockDuration;
    }

}
