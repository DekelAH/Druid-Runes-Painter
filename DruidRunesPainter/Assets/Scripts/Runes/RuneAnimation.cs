using System;
using UnityEngine;

namespace Assets.Scripts.Runes
{
    public class RuneAnimation : RuneDrawingAreaBase
    {
        #region Editor

        [SerializeField]
        private Animator _runeAnim;

        #endregion

        #region Methods

        protected override void DrawInternal()
        {
            _runeAnim.SetTrigger("Paint");
        }

        #endregion
    }
}
