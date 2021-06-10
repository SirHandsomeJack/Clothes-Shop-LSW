﻿using UnityEngine;
using UnityEngine.Events;

namespace SirHandsomeJack.Unity
{
    public class OnValueChangedSplitter : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent TrueEvent;
        public UnityEvent FalseEvent;

        public virtual void OnValueChanged(bool status)
        {
            if (status) TrueEvent.Invoke();
            else FalseEvent.Invoke();
        }
    }
}
