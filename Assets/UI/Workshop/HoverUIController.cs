using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.Workshop
{
    public class HoverUIController : MonoBehaviour
    {
        private static readonly int EnterRobot = Animator.StringToHash("enterRobot");
        private static readonly int ExitGame = Animator.StringToHash("exitGame");
        private static readonly int EnterSettings = Animator.StringToHash("enterSettings");
        [SerializeField] private string actionName;
        [SerializeField] private TextMeshPro label;
        [SerializeField] private Animator animationService;
        private InputAction _mousePress;

        private void Awake()
        {
            _mousePress = InputSystem.actions.FindAction("select");
        }

        private void OnMouseExit()
        {
            label.text = "";
            gameObject.layer = 1;
        }

        private void OnMouseOver()
        {
            label.text = actionName;
            gameObject.layer = 7;
            if (!_mousePress.IsPressed()) return;
            switch (actionName)
            {
                case "Enter":
                    animationService.SetBool(EnterRobot, true);
                    // TODO: Enter Level1
                    break;
                case "Exit":
                    animationService.SetBool(ExitGame, true);
                    Invoke(nameof(QuitGame), 1);
                    break;
                case "Settings":
                    animationService.SetBool(EnterSettings, true);
                    // TODO: Enter Settings Menu
                    animationService.SetBool(EnterSettings, false);
                    break;
            }
        }
        private void QuitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}