using Assets.Scripts.Timers;
using System;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class FillManaActivity
    {
        #region Consts

        private const float MANA_TO_ADD = 30f;
        private const float MANA_INCREASE_TIME = 4f;

        #endregion

        #region Fields

        private static FillManaActivity _instance;
        private readonly PeriodTickTimer _fillManaTimer;

        #endregion

        #region Constructors

        private FillManaActivity()
        {
            _fillManaTimer = new PeriodTickTimer(MANA_INCREASE_TIME);
            _fillManaTimer.Tick += OnTimerTick;
            _fillManaTimer.Begin();
        }

        #endregion

        #region Methods

        private void OnTimerTick()
        {
            PlayerModelProvider.Instance.Get.AddMana(MANA_TO_ADD);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void StartFillManaActivity()
        {
            _instance = new FillManaActivity();
        }

        #endregion
    }
}
