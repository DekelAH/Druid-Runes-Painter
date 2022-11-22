
using Assets.Scripts.Infastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Runes
{
    public class ManaBar : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Image _manaFillImage;

        [SerializeField]
        private Text _manaText;

        #endregion

        #region Methods

        private void Start()
        {
            SetManaFillAmount();
            SubscribeToEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeToEvents();
        }

        private void SetManaFillAmount()
        {
            _manaFillImage.fillAmount = PlayerModelProvider.Instance.Get.ManaAmount / PlayerModelProvider.Instance.Get.MaxManaAmount;
            _manaText.text = PlayerModelProvider.Instance.Get.ManaAmount.ToString();
        }

        private void SubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged += UpdateManaBar;
        }

        private void UnsubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged -= UpdateManaBar;
        }

        private void UpdateManaBar(float manaAmount)
        {
            _manaFillImage.fillAmount = manaAmount / PlayerModelProvider.Instance.Get.MaxManaAmount;
            _manaText.text = manaAmount.ToString();
        }

        #endregion
    }
}