using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _button;

    public event Action OnButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        _windowGroup.alpha = 0f;
        _button.interactable = false;
    }

    public void Open()
    {
        _windowGroup.alpha = 1f;
        _button.interactable = true;
    }

    public void OnButtonClick()
    {
        OnButtonClicked?.Invoke();
    }
}
