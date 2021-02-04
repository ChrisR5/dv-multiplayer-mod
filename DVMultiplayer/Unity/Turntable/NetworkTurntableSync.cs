﻿using DV.CabControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class NetworkTurntableSync : MonoBehaviour
{
    private TurntableController turntable;
    private LeverBase lever;
    private float prevLeverAngle;
    private Transform playerCameraTransform;
    private TurntableControlKeyboardInput keyboardInput;
    private Coroutine coroutineInputLever;
    private void Awake()
    {
        turntable = GetComponent<TurntableController>();
        lever = turntable.leverGO.GetComponent<LeverBase>();
        keyboardInput = turntable.GetComponentInChildren<TurntableControlKeyboardInput>();
        keyboardInput.enabled = false;
        playerCameraTransform = PlayerManager.PlayerCamera.transform;
        coroutineInputLever = SingletonBehaviour<CoroutineManager>.Instance.Run(CheckInputLever());
        turntable.Snapped += Turntable_Snapped;
    }

    private void OnDestroy()
    {
        SingletonBehaviour<CoroutineManager>.Instance.Stop(coroutineInputLever);
        turntable.Snapped -= Turntable_Snapped;
        keyboardInput.enabled = true;
    }

    private void Turntable_Snapped()
    {
        if(!SingletonBehaviour<NetworkTurntableManager>.Instance.IsChangeByNetwork)
            SingletonBehaviour<NetworkTurntableManager>.Instance.OnTurntableSnap(turntable, turntable.turntable.currentYRotation);
    }

    private IEnumerator CheckInputLever()
    {
        yield return new WaitUntil(() => {
            return (lever.Value < .45f || lever.Value > .55f) && lever.IsGrabbedOrHoverScrolled();
        });
        yield return new WaitUntil(() => {
            OnTurntableLeverAngleChanged(lever.Value);
            return lever.Value > .45f && lever.Value < .55f && !lever.IsGrabbedOrHoverScrolled();
        });
        OnTurntableRotationChanged(turntable.turntable.targetYRotation);
        yield return CheckInputLever();
    }

    private void OnTurntableLeverAngleChanged(float value)
    {
        if (prevLeverAngle != value)
        {
            prevLeverAngle = value;
            SingletonBehaviour<NetworkTurntableManager>.Instance.OnTurntableRotationChanged(turntable, value, true);
        }
    }

    private void OnTurntableRotationChanged(float targetYRotation)
    {
        SingletonBehaviour<NetworkTurntableManager>.Instance.OnTurntableRotationChanged(turntable, targetYRotation, false);
    }
}