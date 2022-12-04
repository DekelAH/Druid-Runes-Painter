using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(menuName = "Data Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public event Action<float> ManaAmountChanged;
        public event Action<float> HealthAmountChanged;

        #endregion

        #region Consts

        private const float MAX_MANA = 100f;
        private const float MIN_MANA = 0f;

        #endregion

        #region Editor

        [SerializeField]
        private float _manaAmount;

        [SerializeField]
        private float _healthAmount;

        #endregion

        #region Methods

        public void AddMana(float manaToAdd)
        {
            _manaAmount = Mathf.Clamp(_manaAmount + manaToAdd, MIN_MANA, MAX_MANA);
            ManaAmountChanged?.Invoke(_manaAmount);
        }

        public void TakeMana(float manaToTake)
        {
            _manaAmount = Mathf.Max(0, _manaAmount - manaToTake);
            ManaAmountChanged?.Invoke(_manaAmount);
        }

        public void AddHealth(float healthToAdd)
        {
            _healthAmount = Mathf.Clamp(_healthAmount + healthToAdd, MIN_MANA, MAX_MANA);
            HealthAmountChanged?.Invoke(_healthAmount);
        }

        public void TakeHealth(float healthToTake)
        {
            _healthAmount = Mathf.Max(0, _healthAmount - healthToTake);
            HealthAmountChanged?.Invoke(_healthAmount);
        }

        #endregion

        #region Properties

        public float ManaAmount => _manaAmount;
        public float HealthAmount => _healthAmount;
        public float MaxManaAmount => MAX_MANA;

        #endregion
    }
}
