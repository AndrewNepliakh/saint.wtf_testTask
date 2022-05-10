using System.Collections;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class MainManager : MonoBehaviour, IMainManager
    {
        [Inject] private IUserManager _userManager;
        [Inject] private IStateManager _stateManager;

        private void Start()
        {
            _stateManager.EnterState<GameState>();
        }

        private void Update()
        { 
            _stateManager.ActiveState.Update();
        }

        private void OnApplicationQuit()
        {
           SaveManager.Save(_userManager);
        }
    }
}
