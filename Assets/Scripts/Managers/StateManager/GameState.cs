using System.Collections;
using Controllers.SceneController;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class GameState : IState
    {
        [Inject] private DiContainer _diContainer;
        private SceneController _sceneBodyPrefab;

        public void Enter()
        {
            _sceneBodyPrefab = Resources.Load<SceneController>(Constants.SCENE_PATH);
            _sceneBodyPrefab =
                _diContainer.InstantiatePrefab(_sceneBodyPrefab, Vector3.zero, Quaternion.identity, null)
                    .GetComponent<SceneController>();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}