using System;
using Buttons;
using Panels;
using static Other.Enums;

namespace Other {
  public static class EnumExtensions {
    public static int GetPanelType(this NavigationType type) {
      return type switch {
        NavigationType.Left => (int)NavigationPanelPosition.Left,
        NavigationType.Right => (int)NavigationPanelPosition.Right,
        NavigationType.Middle => (int)NavigationPanelPosition.Middle,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
      };
    }
  }
}