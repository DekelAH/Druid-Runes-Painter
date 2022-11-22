using Runes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RuneButtonSpawner : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private CastRuneButton[] _runeButtons;

        [SerializeField]
        private Transform _selfPosition;

        #endregion

        #region Methods

        private void Start()
        {
            SpawnRuneButtons(_runeButtons);
        }

        private void SpawnRuneButtons(CastRuneButton[] runeButtons)
        {
            foreach (var runeBtn in runeButtons)
            {
                Instantiate(runeBtn, _selfPosition);         
            }
        }

        #endregion
    }
}
