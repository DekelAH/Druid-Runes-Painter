

using Assets.Scripts.Infastructure;
using Runes;
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
        protected RuneDrawingArea _runeDrawingArea;

        #endregion

        #region Fields

        protected bool _isPainting;

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
            _runeDrawingArea.BeginDraw += OnBeginDraw;
            _runeDrawingArea.EndDraw += OnEndDraw;
        }

        private void UnsubscribeToEvents()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged -= OnCheckManaAmount;
        }

        private void OnEndDraw(bool isDrawing)
        {
            _isPainting = isDrawing;
        }

        private void OnBeginDraw(bool isDrawing)
        {
            _isPainting = isDrawing;
        }

        private void OnCheckManaAmount(float manaAmount)
        {
            _selfButton.interactable = _manaToTake <= manaAmount;
        }

        public void SetRuneDrawingArea(RuneDrawingArea runeDrawingArea)
        {
            _runeDrawingArea = runeDrawingArea;
        }

        public virtual void OnClick()
        {
            if (!_isPainting)
            {
                PlayerModelProvider.Instance.Get.TakeMana(_manaToTake);

                _runeDrawingArea.Draw();
            }
        }

        #endregion
    }
}