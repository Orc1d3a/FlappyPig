using System;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    [SerializeField] private WindowsManager _windowsManager;

    public event Action JumpPressed;
    public event Action ShotPressed;

    private KeyCode _jumpButton = KeyCode.Space;
    private KeyCode _shotButton = KeyCode.E;

    private void Update()
    {
        if (_windowsManager.IsPlay == false)
            return;

        if (Input.GetKeyDown(_jumpButton))
            JumpPressed?.Invoke();
        if (Input.GetKeyDown(_shotButton))
            ShotPressed?.Invoke();
    }
}
