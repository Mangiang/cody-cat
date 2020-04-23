using UnityEngine;
using System.Collections.Generic;

public class TutoManager : MonoBehaviour
{
    public static TutoManager singleton;

    private State prevState;
    private State currentState;

    private Dictionary<StateEnum, State> states;

    public bool blockConsole = false;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
    }


    private void Start()
    {
        states = new Dictionary<StateEnum, State>();

        states[StateEnum.INTRO] = new IntroState();
        states[StateEnum.FIRST_DIALOG] = new FirstDialogState();
        states[StateEnum.FIRST_VISUAL_SCRIPTING] = new FirstVisualScriptingState();
        states[StateEnum.FIRST_DOOR] = new FirstDoorState();
        states[StateEnum.FINISHED] = new FinishedState();
        states[StateEnum.PAUSE] = new PauseState();

        NextStatus(new IntroState());
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.singleton.consolePanel.activeInHierarchy)
            {
                UIManager.singleton.consolePanel.SetActive(false);
            }
            else
            {
                NextStatus(StateEnum.PAUSE);
            }
        }
    }

    public void NextStatus(State newState)
    {
        if (currentState == newState) return;

        prevState = currentState;
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = newState;
        if (newState != null)
        {
            newState.EnterState();
        }
    }

    public void NextStatus(StateEnum newStateEnum)
    {
        if (newStateEnum == StateEnum.NULL) return;
        NextStatus(states[newStateEnum]);
    }

    public void RevertState()
    {
        NextStatus(prevState);
    }

    public void Exit()
    {
        Application.Quit();
    }
}