using System.Collections;
using Managers;
using UnityEngine;
using Zenject;

public class GameEnterPoint : MonoBehaviour
{
    [Inject] private IStateManager _stateManager;

    private void Awake()
    {
        _stateManager.EnterState<InitialState>();
    }
}