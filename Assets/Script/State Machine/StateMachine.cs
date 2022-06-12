using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected List<State> states = new List<State>();
    private State currentState;

    protected abstract void Initialize();

    void Start()
    {
        Initialize();
        if (states.Count > 0) {
            currentState = states.First();
            currentState.OnEnter();
        }
    }


    void Update()
    {
        if (states.Count <= 0) return;

        for (int i = 0; i < currentState.transitions.Count; i++)
        {
            bool shouldChangeState = currentState.transitions[i].shouldNext.Invoke();
            if (shouldChangeState)
            {
                Debug.Log("Should Transition " + currentState + " >>> " + currentState.transitions[i].nextState);
                currentState.OnExit();
                currentState = currentState.transitions[i].nextState;
                currentState.OnEnter();
            }
        }
        currentState.OnUpdate();
    }

}
