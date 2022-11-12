using System;
using Buttons.Base;
using Panels;
using UnityEngine;
using UnityEngine.UI;
using static Other.Enums;
using static Other.Enums;

namespace Buttons {
  [RequireComponent(typeof(Button))]
  public class NavigationButton : NavigationButtonAnimation {
    [SerializeField]
    private NavigationType _type;
    [SerializeField]
    private Button _button;

    private new void Awake() {
      base.Awake();
      _button = GetComponent<Button>();

      if (_type != NavigationType.Middle) {
        Hide();
      }
    }

    private void Start() {
      _button.onClick.AddListener(() => OnClick(_type));
    }

    protected override void OnClick(NavigationType type) {
      base.OnClick(type);
      ScrollPanel.Swipe?.Invoke(type);
      GameManager.SetCurrentPanelType(type);
    }
  }
}