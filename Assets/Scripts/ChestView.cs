using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ChestSystem
{
    public class ChestView : MonoBehaviour
    {
        public ChestController _chestController;

        public GameObject _unlockPopup;
        public Text _coinsRequiredText;
        public Text _gemsRequiredText;
        public Text _timerTxt;
        public Button _button;
        public Transform parent;

        private void Awake() {
          parent = this.transform.parent.gameObject.transform;
        }
        public void CreateRefToController(ChestController chestController)
        {
            _chestController = chestController;
        }

        public void UnlockPopup()
        {
            _unlockPopup.SetActive(true);
        }
        public void OpenChestUsingGems()
        {
            _chestController.ActivateChestUsingGems();
        }
        public void OpenChestUsingCoins()
        {
            if (_chestController.ActivateChestUsingCoins())
            {
                StartCoroutine(_chestController.TimerCoroutine());
            }
        }
    }


}
