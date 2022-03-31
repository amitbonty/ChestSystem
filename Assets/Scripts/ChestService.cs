using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ChestSystem
{
    public class ChestService : Singleton<ChestService>
    {

        ChestController _chestController;
        [SerializeField]
        ControllerChestSlot[] _chestSlots;

        public int gems = 10;
        public int coins = 1000;

        [SerializeField]
        public Text _gemTxt;

        [SerializeField]
        public Text _coinsTxt;


        private void Update()
        {
            UpdateScore();
        }

        public void LoadChest()
        {
            for (int i = 0; i < _chestSlots.Length; i++)
            {
                if (_chestSlots[i]._isEmpty)
                {
                    int RandomNumber = Random.Range(0, ChestConfigurations.Instance._configMap.Length - 1);
                    CreateChest(ChestConfigurations.Instance._configMap[RandomNumber]._chestSO, ChestConfigurations.Instance._configMap[RandomNumber]._chestView, _chestSlots[i].gameObject.transform);
                    _chestSlots[i]._isEmpty = false;
                    break;
                }
                else
                {
                    Debug.Log("Chest slot is full");
                }
            }

        }

        public void UpdateScore()
        {
            _gemTxt.text = "Gems--" + gems.ToString();
            _coinsTxt.text = "Coins--" + coins.ToString();
        }


        private void CreateChest(ChestSO chestSO, ChestView chestView, Transform parent)
        {
            ChestModel chestModel = new ChestModel(chestSO);
            _chestController = new ChestController(chestModel, chestView, parent);
        }
        public void UnloadChest(Transform parent)
        {
            for (int i = 0; i < _chestSlots.Length; i++)
            {
                if (!_chestSlots[i]._isEmpty && _chestSlots[i].gameObject==parent.gameObject)
                {
                    Destroy(_chestSlots[i].transform.GetChild(0).gameObject);
                    _chestSlots[i]._isEmpty = true;
                    break;
                }
            }
        }


    }

}
