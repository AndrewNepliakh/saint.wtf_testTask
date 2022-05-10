using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Managers
{
    public class InitialState : IState
    {
        private IUserManager _userManager;

        [Inject]
        private InitialState(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public void Enter()
        { 
            LoadUserData();
            SceneManager.LoadScene(Constants.MAIN_SCENE);
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }

        private void LoadUserData()
        {
            var saveData = SaveManager.Load();
            _userManager.Init(saveData.UserData);
        }
    }
}