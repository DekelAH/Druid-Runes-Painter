using Assets.Scripts.Infastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Image _healthFillImage;

        [SerializeField]
        private Text _healthText;

        #endregion

        #region Methods

        private void Start()
        {
            SetHealthFillAmount();
            SubscribeToEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeToEvents();
        }

        private void SetHealthFillAmount()
        {
            _healthFillImage.fillAmount = PlayerModelProvider.Instance.Get.HealthAmount / PlayerModelProvider.Instance.Get.MaxManaAmount;
            _healthText.text = PlayerModelProvider.Instance.Get.HealthAmount.ToString();
        }

        private void SubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.HealthAmountChanged += UpdateHealthBar;
        }

        private void UnsubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.HealthAmountChanged -= UpdateHealthBar;
        }

        private void UpdateHealthBar(float healthAmount)
        {
            _healthFillImage.fillAmount = healthAmount / PlayerModelProvider.Instance.Get.MaxManaAmount;
            _healthText.text = healthAmount.ToString();
        }

        #endregion
    }
}
