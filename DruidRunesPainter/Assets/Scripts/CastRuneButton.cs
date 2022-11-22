

using Assets.Scripts.Infastructure;
using System;
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

        [SerializeField]
        private DruidRunePainter _druidRunePainter;

        #endregion

        #region Fields

        private bool _isPainting;

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
            _druidRunePainter.BeginDraw += OnBeginDraw;
            _druidRunePainter.EndDraw += OnEndDraw;
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

        public void OnClick()
        {
            if (!_isPainting)
            {
                PlayerModelProvider.Instance.Get.TakeMana(_manaToTake);

                _druidRunePainter.Draw();
            }
        }

        #endregion
    }
}