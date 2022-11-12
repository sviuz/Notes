using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static Other.Enums;

namespace Buttons.Base {
  public class NavigationButtonAnimation : BaseNavigationButton {
    private static Action _hideButton;
    [SerializeField]
    private Image _selectedImage;
    [SerializeField]
    private bool _isActivated;

    protected void Awake() {
      Sub();
    }

    private void OnDestroy() {
      Sub(false);
    }

    private void Sub(bool sub = true) {
      if (sub) {
        _hideButton += Hide;
        return;
      }

      _hideButton -= Hide;
    }

    protected override void OnClick(NavigationType type) {
      base.OnClick(type);

      if (_isActivated) {
        return;
      }

      _hideButton?.Invoke();
      _isActivated = !_isActivated;

      Show(_isActivated);
    }

    protected void Hide() {
      _selectedImage.DOFade(0, 0.3f);
      _isActivated = false;
    }

    private void Show(bool show) {
      _selectedImage.DOFade(GetButtonFade(show), 0.3f);
    }

    private static float GetButtonFade(bool show) => show ? 0.5f : 0f;
  }
}