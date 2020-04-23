using UnityEngine;

public class CharController : MonoBehaviour
{
    int speed = 200;
    CharacterController charController;
    Controller controller;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        controller = GetComponent<Controller>();
        controller.Register();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && !TutoManager.singleton.blockConsole)
        {
            UIManager.singleton.ShowConsole();
        }
    }
}