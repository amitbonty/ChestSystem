using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem
{
    public class ChestModel
    {
        public ChestTypes _chestType;
        public int _coinsRequired;
        public int _gemsRequired;
        public int _coinsGained;
        public int _gemsGained;
        public float unlockDuration;

        public ChestModel(ChestSO chestSO)
        {
            _chestType = chestSO._chestType;
            _coinsRequired = Random.Range(chestSO._maxCoinsRequired, chestSO._minCoinsRequired);
            _gemsRequired = Random.Range(chestSO._maxGemsRequired, chestSO._minGemsRequired);
            _coinsGained = chestSO._coinsGained;
            _gemsGained = chestSO._GemsGained;
            unlockDuration = chestSO.unlockDuration;

        }
    }
}

