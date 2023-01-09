using Assets.Scripts.Infastructure;
using UnityEngine;

namespace Assets.Scripts.Rune_Buttons
{
    public class HealingRuneButton : CastRuneButtonBase
    {
        #region Editor

        [SerializeField]
        private float _healthToAdd;

        #endregion

        #region Methods

        public override void OnClick()
        {
            PlayerModelProvider.Instance.Get.TakeMana(_manaToTake);
            PlayerModelProvider.Instance.Get.AddHealth(_healthToAdd);

            _runeDrawingArea.Draw();
        }

        #endregion
    }
}
