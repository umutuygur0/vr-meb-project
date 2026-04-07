using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class ActionSequence : MonoBehaviour
{
    [System.Serializable]
    public class SequenceStep
    {
        public string name;
        public UnityEvent action;
        public UnityEvent onStepComplete;
    }

    [SerializeField] private List<SequenceStep> steps;
    private int currentStepIndex = 0;

    public void StartSequence()
    {
        currentStepIndex = 0;
        PlayStep();
    }

    private void PlayStep()
    {
        if (currentStepIndex >= steps.Count) return;
        
        Debug.Log($"Playing Step: {steps[currentStepIndex].name}");
        steps[currentStepIndex].action?.Invoke();
    }

    public void Advance()
    {
        currentStepIndex++;
        PlayStep();
    }
}