#region Copy
// This file is © 2022 Rumyancev Pavel <paulrumyancev@gmail.com>
// Vector. School of Game development
#endregion
using UnityEngine;
    
namespace Runes
{
    public class DruidRunePainter : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Transform[] _runeDrawPoints;

        [SerializeField]
        private Transform _runeBrush;

        [SerializeField]
        private float _moveSpeed = 0.01f;
        
        #endregion
    }
}