

using Assets.Scripts.Infastructure;
using Assets.Scripts.Runes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Rune_Buttons
{
    public class CastRuneButtonBase : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Button _selfButton;

        [SerializeField]
        protected float _manaToTake;

        [SerializeField]
        protected RuneDrawingAreaBase _runeDrawingArea;

        #endregion

        #region Methods

        private void Start()
        {
            SubscribeToEvents();

            _selfButton.interactable = PlayerModelProvider.Instance.Get.ManaAmount >= _manaToTake;
        }

        private void OnDestroy()
        {
            UnsubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged += OnManaAmountChanged;
            _runeDrawingArea.BeginDraw += OnBeginDraw;
            _runeDrawingArea.EndDraw += OnEndDraw;
        }

        private void UnsubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged -= OnManaAmountChanged;
            _runeDrawingArea.BeginDraw -= OnBeginDraw;
            _runeDrawingArea.EndDraw -= OnEndDraw;
        }

        private void OnEndDraw()
        {
            _selfButton.interactable = PlayerModelProvider.Instance.Get.ManaAmount > _manaToTake;
        }

        private void OnBeginDraw()
        {
            _selfButton.interactable = false;
        }

        private void OnManaAmountChanged(float mana) 
        {
            _selfButton.interactable = mana >= _manaToTake;
        }

        public void SetButtonInteractable(bool isInteractable)
        {
            _selfButton.interactable = isInteractable;
        }

        public void SetRuneDrawingArea(RuneDrawingAreaBase runeDrawingArea)
        {
            _runeDrawingArea = runeDrawingArea;
        }

        public virtual void OnClick()
        {
            if (PlayerModelProvider.Instance.Get.ManaAmount >= _manaToTake)
            {
                PlayerModelProvider.Instance.Get.TakeMana(_manaToTake);

                _runeDrawingArea.Draw();
            }
        }

        #endregion

        #region Properties

        public float ManaToTake => _manaToTake;

        #endregion
    }
}