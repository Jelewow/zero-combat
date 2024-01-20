﻿using System;
using UnityEngine;
using ZeroCombat.Constants;
using ZeroCombat.Logic.Animator;

namespace ZeroCombat.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;

        private void Update()
        {
            _animator.SetFloat(Constant.Animator.Variables.Speed, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }

        private static readonly int MoveHash = Animator.StringToHash("Walking");
        private static readonly int AttackHash = Animator.StringToHash("AttackNormal");
        private static readonly int HitHash = Animator.StringToHash("Hit");
        private static readonly int DieHash = Animator.StringToHash("Die");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _idleStateFullHash = Animator.StringToHash("Base Layer.Idle");
        private readonly int _attackStateHash = Animator.StringToHash("Attack Normal");
        private readonly int _walkingStateHash = Animator.StringToHash("Run");
        

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }

        public Animator Animator;

        public bool IsAttacking => State == AnimatorState.Attack;


        public void PlayHit() => Animator.SetTrigger(HitHash);

        public void PlayAttack() => Animator.SetTrigger(AttackHash);

        public void PlayDeath() => Animator.SetTrigger(DieHash);

        public void ResetToIdle() => Animator.Play(_idleStateHash, -1);

        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash) =>
            StateExited?.Invoke(StateFor(stateHash));

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == Constant.Animator.IdleHash)
                state = AnimatorState.Idle;
            else if (stateHash == _attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == Constant.Animator.MoveHash)
                state = AnimatorState.Walking;
            else if (stateHash == Constant.Animator.DiedHash)
                state = AnimatorState.Died;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}