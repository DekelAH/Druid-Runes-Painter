
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
namespace Assets.Scripts.Runes
{
    public abstract class RuneDrawingAreaBase : MonoBehaviour
    {
        #region Events

        public event Action BeginDraw;
        public event Action EndDraw;

        #endregion

        #region Editor

        [SerializeField]
        protected Transform[] _runeDrawPoints;

        [SerializeField]
        protected Transform _runeBrush;

        [SerializeField]
        protected float _moveSpeed = 0.01f;

        #endregion

        #region Methods

        public void Draw()
        {
            DrawInternal();
        }

        protected abstract void DrawInternal();

        protected void OnBeginDraw()
        {
            BeginDraw?.Invoke();
        }

        protected void OnEndDraw()
        {
            EndDraw?.Invoke();
        }

        #endregion
    }
}