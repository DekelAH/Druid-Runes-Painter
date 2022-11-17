using Assets.Scripts.Infastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Timers
{
    public class PeriodTickTimer
    {
        #region Events

        public event Action Tick;

        #endregion

        #region Fields

        private Coroutine _timerCoroutine;
        private readonly float _time;

        #endregion

        #region Constructors

        public PeriodTickTimer(float time)
        {
            _time = time;
        }

        #endregion

        #region Methods

        public void Begin()
        {
            _timerCoroutine = CoroutineService.Instance.BeginCoroutine(CoroutineTimer(_time));
        }

        public void End()
        {
            CoroutineService.Instance.EndCoroutine(_timerCoroutine);
        }

        private IEnumerator CoroutineTimer(float time)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(time);
                Tick?.Invoke();
            }
        }

        #endregion
    }
}
