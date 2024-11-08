using System;
using System.Collections;
using CardboardCore.DI;
using CardboardCore.UI;
using CardboardCore.Utilities;
using PeekABoo.UI.Screens;
using UnityEngine;

namespace PeekABoo.Characters.Players
{
    public enum StaminaState
    {
        Normal,
        Sprinting,
        AwaitingRecovery,
        Recovering
    }

    public class PlayerCharacterStamina : CharacterComponent
    {
        [Inject] private UIManager uiManager;

        [SerializeField] private float staminaRecoveryRate = 0.1f;
        [SerializeField] private float sprintStaminaCost = 0.05f;
        [SerializeField] private float durationBeforeRecovery = 1f;

        private float currentStamina;
        private Coroutine recoveryTimeoutCoroutine;

        private GameplayScreen gameplayScreen;

        public StaminaState StaminaState { get; private set; }
        public bool IsExhausted { get; private set; }

        protected override void OnInjected()
        {
            base.OnInjected();

            gameplayScreen = uiManager.GetScreen<GameplayScreen>();

            currentStamina = 1f;
            StaminaState = StaminaState.Normal;
        }

        private void Update()
        {
            switch (StaminaState)
            {
                case StaminaState.Sprinting:

                    currentStamina -= sprintStaminaCost * Time.deltaTime;

                    if (currentStamina <= 0)
                    {
                        currentStamina = 0;

                        SetStaminaState(StaminaState.AwaitingRecovery);
                        recoveryTimeoutCoroutine = StartCoroutine(StartRecoveryTimeout());

                        IsExhausted = true;

                        gameplayScreen?.ShowExhaustedState();
                    }

                    break;

                case StaminaState.Recovering:

                    currentStamina += staminaRecoveryRate * Time.deltaTime;

                    if (currentStamina >= 1)
                    {
                        currentStamina = 1;

                        SetStaminaState(StaminaState.Normal);
                        IsExhausted = false;

                        gameplayScreen?.HideExhaustedState();
                    }

                    break;
            }

            gameplayScreen?.UpdateStaminaBar(currentStamina);
        }

        private void SetStaminaState(StaminaState newState)
        {
            if (newState == StaminaState)
            {
                return;
            }

            Log.Write(newState);

            if (recoveryTimeoutCoroutine != null)
            {
                StopCoroutine(recoveryTimeoutCoroutine);
                recoveryTimeoutCoroutine = null;
            }

            if (newState == StaminaState.AwaitingRecovery)
            {
                recoveryTimeoutCoroutine = StartCoroutine(StartRecoveryTimeout());
            }

            StaminaState = newState;
        }

        private IEnumerator StartRecoveryTimeout()
        {
            yield return new WaitForSeconds(durationBeforeRecovery);

            SetStaminaState(StaminaState.Recovering);
        }

        public bool BeginSprint()
        {
            if (IsExhausted)
            {
                return false;
            }

            switch (StaminaState)
            {
                case StaminaState.Normal:
                case StaminaState.Recovering:
                case StaminaState.AwaitingRecovery:

                    SetStaminaState(StaminaState.Sprinting);

                    break;
            }

            return true;
        }

        public void EndSprint()
        {
            if (StaminaState != StaminaState.Sprinting)
            {
                return;
            }

            SetStaminaState(StaminaState.AwaitingRecovery);
        }
    }
}
