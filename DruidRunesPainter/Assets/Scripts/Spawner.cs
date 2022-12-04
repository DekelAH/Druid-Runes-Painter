using Assets.Scripts.Rune_Buttons;
using Runes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        #region Editor

        [Header("Draw Area")]
        [SerializeField]
        private RuneDrawingArea[] _drawAreas;

        [Header("Button Area")]
        [SerializeField]
        private CastRuneButtonBase[] _runeButtons;

        [SerializeField]
        private Transform _buttonAreaPosition;

        #endregion

        #region Methods

        private void Start()
        {
            SpawnRuneButtons(_runeButtons, _drawAreas);
        }

        private void SpawnRuneButtons(CastRuneButtonBase[] runeButtons, RuneDrawingArea[] drawAreas)
        {
            foreach (var runeBtn in runeButtons)
            {
                foreach (var runeDrawArea in drawAreas)
                {
                    if (runeBtn.CompareTag(runeDrawArea.tag))
                    {
                        runeBtn.gameObject.GetComponent<CastRuneButtonBase>();
                        runeBtn.SetRuneDrawingArea(runeDrawArea);
                    }
                }

                Instantiate(runeBtn, _buttonAreaPosition);
            }
        }

        #endregion
    }
}
