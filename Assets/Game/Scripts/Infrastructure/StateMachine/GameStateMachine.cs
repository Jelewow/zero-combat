﻿using System;
using System.Collections.Generic;
using ZeroCombat.Bootstrapper;
using ZeroCombat.Factory;
using ZeroCombat.Infrastructure.Services;
using ZeroCombat.Infrastructure.Services.PersistentProgress;
using ZeroCombat.Logic.UI;

namespace ZeroCombat.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices allServices)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, allServices ),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain, allServices.Single<IGameFactory>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, allServices.Single<IPersistantProgressService>(), allServices.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
             
            TState state = GetState<TState>();
            _activeState = state;
            
            return state;
        }
        
        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}