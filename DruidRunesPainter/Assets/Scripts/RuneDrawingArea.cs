
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
namespace Runes
{
    public class RuneDrawingArea : MonoBehaviour
    {
        #region Events

        public event Action<bool> BeginDraw;
        public event Action<bool> EndDraw;

        #endregion

        #region Editor

        [SerializeField]
        private Transform[] _runeDrawPoints;

        [SerializeField]
        private Transform _runeBrush;

        [SerializeField]
        private float _moveSpeed = 0.01f;

        #endregion

        #region Fields

        private readonly Stack<Vector3> _runePath = new Stack<Vector3>();

        private bool _isDrawing;

        #endregion

        #region Methods

        public void Draw()
        {
            CreateRunePath();
            _runeBrush.position = _runePath.Pop();
            DrawInternal();
        }

        private void DrawInternal()
        {
            if (_runePath.Count > 0)
            {
                var fromPoint = _runeBrush.position;
                var toPoint = _runePath.Pop();
                StartCoroutine(RuneDrawing(fromPoint, toPoint, _runeBrush, _moveSpeed,DrawInternal));
            }

            _isDrawing = false;
            EndDraw?.Invoke(_isDrawing);
        }

        private IEnumerator RuneDrawing(Vector3 currentPoint, Vector3 nextPoint, Transform runeBrushPosition,float inTime, Action drawInternalCallBack)
        {
            var accTime = 0f;
            var moveFactor = 0f;

            while (moveFactor < 1)
            {
                runeBrushPosition.position = Vector3.Lerp(currentPoint, nextPoint, moveFactor);
                moveFactor = accTime / inTime;
                accTime += Time.deltaTime;

                _isDrawing = true;
                BeginDraw?.Invoke(_isDrawing);

                yield return null;
            }

            drawInternalCallBack?.Invoke();
        }

        private void CreateRunePath()
        {
            _runePath.Clear();

            for (int i = _runeDrawPoints.Length - 1; i >= 0; i--)
            {
                _runePath.Push(_runeDrawPoints[i].position);
            }
        }

        #endregion
    }
}