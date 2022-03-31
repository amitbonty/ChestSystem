using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestSystem;

    public class ChestController
    {
        public ChestModel _chestModel
        {
            get;
        }
        public ChestView _chestView
        {
            get;
        }
        public ChestController(ChestModel chestModel, ChestView chestView, Transform parent)
        {
            _chestModel = chestModel;
            _chestView = GameObject.Instantiate<ChestView>(chestView, parent.position, Quaternion.identity, parent);
            UpdatelockedChest();
            _chestView.CreateRefToController(this);
        }

        public void UpdatelockedChest()
        {
            _chestView._coinsRequiredText.text = _chestModel._coinsRequired.ToString();
            _chestView._gemsRequiredText.text = _chestModel._gemsRequired.ToString();
        }
        public void ActivateChestUsingGems()
        {
            if (ChestService.Instance.gems >= _chestModel._gemsRequired)
            {
                _chestView._button.interactable = false;
                ChestService.Instance.gems -= _chestModel._gemsRequired;
                ChestService.Instance.coins += _chestModel._coinsGained;
                ChestService.Instance.gems += _chestModel._gemsGained;
                ChestService.Instance.UnloadChest(_chestView.parent);
            }
            else
            {
                Debug.Log("Not enough coins!");
            }

            _chestView._unlockPopup.SetActive(false);
        }
        public bool ActivateChestUsingCoins()
        {
            if (ChestService.Instance.coins >= _chestModel._coinsRequired)
            {
                _chestView._button.interactable = false;
                ChestService.Instance.coins -= _chestModel._coinsRequired;
                _chestView._unlockPopup.SetActive(false);
                _chestView._timerTxt.gameObject.SetActive(true);
                return true;
            }
            else
            {
                Debug.Log("Not enough gems!");
            }
            _chestView._unlockPopup.SetActive(false);
            return false;
        }
        public IEnumerator TimerCoroutine()
        {
            while (_chestModel.unlockDuration >= 0)
            {
                _chestView._timerTxt.text = _chestModel.unlockDuration.ToString();
                yield return new WaitForSeconds(1f);
                Debug.Log(_chestModel.unlockDuration);
                _chestModel.unlockDuration -= 1f;
            }
            RewardsGainedUsingGems();
            _chestView._timerTxt.gameObject.SetActive(false);
        }
        public void RewardsGainedUsingGems()
        {
            ChestService.Instance.coins += _chestModel._coinsGained;
            ChestService.Instance.gems += _chestModel._gemsGained;
            ChestService.Instance.UnloadChest(_chestView.parent);
            _chestView._unlockPopup.SetActive(false);
        }
    }

