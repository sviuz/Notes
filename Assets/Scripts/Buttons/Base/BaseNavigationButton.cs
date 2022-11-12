using System;
using UnityEngine;
using static Other.Enums;

namespace Buttons.Base {
  public class BaseNavigationButton : MonoBehaviour {
    protected virtual void OnClick(NavigationType type) {
      switch (type) {
        case NavigationType.Left:
          break;
        case NavigationType.Right:
          break;
        case NavigationType.Middle:
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(type), type, null);
      }
    }
  }
}