using System.Collections;
using Controllers.PlayerController;
using Controllers.SceneController;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameState : IState
    {
        [Inject] private DiContainer _diContainer;
        
        private SceneController _sceneBody;
        private PlayerController _player;

        public void Enter()
        {
            var sceneBodyPrefab = Resources.Load<SceneController>(Constants.SCENE_PATH);
            _sceneBody =
                _diContainer.InstantiatePrefab(sceneBodyPrefab, Vector3.zero, Quaternion.identity, null)
                    .GetComponent<SceneController>();
            
            var playerPrefab = Resources.Load<PlayerController>(Constants.PLAYER_PATH);
            _player =  _diContainer.InstantiatePrefab(playerPrefab, Vector3.up, Quaternion.identity, null)
                .GetComponent<PlayerController>();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}