using Assets.Scripts.Infastructure;
using Assets.Scripts.Rune_Buttons;
using Assets.Scripts.Runes;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        #region Editor

        [Header("Draw Area")]
        [SerializeField]
        private RuneDrawingAreaBase[] _drawAreas;

        [Header("Button Area")]
        [SerializeField]
        private CastRuneButtonBase[] _runeButtons;

        [SerializeField]
        private Transform _buttonAreaPosition;

        #endregion

        #region Methods

        private void Start()
        {
            PlayerModelProvider.Instance.Get.ManaAmountChanged += OnManaAmountChanged;
            SpawnRuneButtons(_runeButtons, _drawAreas);
        }

        private void SpawnRuneButtons(CastRuneButtonBase[] runeButtons, RuneDrawingAreaBase[] drawAreas)
        {
            foreach (var runeBtn in runeButtons)
            {
                foreach (var runeDrawArea in drawAreas)
                {

                    if (runeBtn.CompareTag(runeDrawArea.tag))
                    {
                        runeBtn.gameObject.GetComponent<CastRuneButtonBase>();
                        runeBtn.SetRuneDrawingArea(runeDrawArea);

                        runeDrawArea.BeginDraw += OnBeginDraw;
                        runeDrawArea.EndDraw += OnEndDraw;
                    }
                }

                Instantiate(runeBtn, _buttonAreaPosition);
            }
        }

        private void OnBeginDraw()
        {
            foreach (var runeBtn in _runeButtons)
            {
                runeBtn.SetButtonInteractable(false);
            }
        }

        private void OnEndDraw()
        {
            foreach (var runeBtn in _runeButtons)
            {
                runeBtn.SetButtonInteractable(PlayerModelProvider.Instance.Get.ManaAmount >= runeBtn.ManaToTake);
            }
        }

        private void OnManaAmountChanged(float mana)
        {
            OnEndDraw();
        }

        #endregion
    }
}
