
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
namespace Assets.Scripts.Runes
{
    public abstract class RuneDrawingAreaBase : MonoBehaviour
    {
        #region Events

        public event Action<bool> BeginDraw;
        public event Action<bool> EndDraw;

        #endregion

        #region Editor

        [SerializeField]
        protected Transform[] _runeDrawPoints;

        [SerializeField]
        protected Transform _runeBrush;

        [SerializeField]
        protected float _moveSpeed = 0.01f;

        #endregion

        #region Fields

        protected bool _isDrawing;

        #endregion

        #region Methods

        public void Draw()
        {
            DrawInternal();
        }

        protected abstract void DrawInternal();

        protected void OnBeginDraw(bool isDrawing)
        {
            BeginDraw?.Invoke(isDrawing);
        }

        protected void OnEndDraw(bool isDrawing)
        {
            EndDraw?.Invoke(isDrawing);
        }

        #endregion
    }
}