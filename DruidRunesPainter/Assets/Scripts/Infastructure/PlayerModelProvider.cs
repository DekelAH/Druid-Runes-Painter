using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerModelProvider
    {
        #region Consts

        private const string PLAYER_MODEL_RESOURCE_NAME = "Player Model";

        #endregion

        #region Fields

        private static PlayerModelProvider _instance;
        private readonly PlayerModel _playerModel;

        #endregion

        #region Constructors

        private PlayerModelProvider(string playerModelResourceName)
        {
            _playerModel = Resources.Load<PlayerModel>(playerModelResourceName);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new PlayerModelProvider(PLAYER_MODEL_RESOURCE_NAME);
                }

                return _instance;
            }
        }

        public PlayerModel Get => _playerModel;

        #endregion


    }
}
