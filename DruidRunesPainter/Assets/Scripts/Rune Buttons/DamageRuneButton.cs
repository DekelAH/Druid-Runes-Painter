using Assets.Scripts.Infastructure;
using UnityEngine;

namespace Assets.Scripts.Rune_Buttons
{
    public class DamageRuneButton : CastRuneButtonBase
    {
        #region Editor

        [SerializeField]
        private float _healthToTake;

        #endregion

        #region Methods

        public override void OnClick()
        {
            if (!_isPainting)
            {
                PlayerModelProvider.Instance.Get.TakeMana(_manaToTake);
                PlayerModelProvider.Instance.Get.TakeHealth(_healthToTake);

                _runeDrawingArea.Draw();
            }
        }

        #endregion
    }
}
