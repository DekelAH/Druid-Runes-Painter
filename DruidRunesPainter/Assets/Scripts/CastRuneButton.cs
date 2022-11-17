

using Assets.Scripts.Infastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Runes
{
    public class CastRuneButton : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Button _selfButton;

        [SerializeField]
        private float _manaToTake;

        #endregion

        #region Methods

        private void Start()
        {
            SubscribeToEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged += OnCheckManaAmount;
        }

        private void UnsubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged -= OnCheckManaAmount;
        }

        private void OnCheckManaAmount(float manaAmount)
        {
            _selfButton.interactable = _manaToTake <= manaAmount;
        }

        public void OnClick()
        {
            PlayerModelProvider.Instance.Get.TakeMana(_manaToTake);
        }

        #endregion
    }
}