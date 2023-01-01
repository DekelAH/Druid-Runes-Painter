using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runes
{
    public class RunePointByPoint : RuneDrawingAreaBase
    {
        #region Fields

        private readonly Stack<Vector3> _runePath = new Stack<Vector3>();

        #endregion

        #region Methods

        protected override void DrawInternal()
        {
            CreateRunePath();
            _runeBrush.position = _runePath.Pop();
            DrawPointByPoint();
        }

        private void DrawPointByPoint()
        {

            if (_runePath.Count > 0)
            {
                var fromPoint = _runeBrush.position;
                var toPoint = _runePath.Pop();
                StartCoroutine(RuneDrawing(fromPoint, toPoint, _runeBrush, _moveSpeed, DrawPointByPoint));
            }

            _isDrawing = false;
            OnEndDraw(_isDrawing);
        }

        private IEnumerator RuneDrawing(Vector3 currentPoint, Vector3 nextPoint, Transform runeBrushPosition, float inTime, Action drawPointByPointCallBack)
        {
            var accTime = 0f;
            var moveFactor = 0f;

            while (moveFactor < 1)
            {
                runeBrushPosition.position = Vector3.Lerp(currentPoint, nextPoint, moveFactor);
                moveFactor = accTime / inTime;
                accTime += Time.deltaTime;

                _isDrawing = true;
                OnBeginDraw(_isDrawing);

                yield return null;
            }

            drawPointByPointCallBack?.Invoke();
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
