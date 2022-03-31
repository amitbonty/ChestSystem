using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace ChestSystem
{
    public class ChestConfigurations : Singleton<ChestConfigurations>
    {
        [Serializable]
        public class ChestPairs
        {
            public ChestSO _chestSO;
            public ChestView _chestView;
        }
        public ChestPairs[] _configMap;
    }
}

