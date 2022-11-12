using Buttons;
using static Other.Enums;

public static class GameManager {
  private static NavigationType _currentPanel;
  public static NavigationType GetCurrentPanelType => _currentPanel;

  
  
  public static void SetCurrentPanelType(NavigationType type) {
    _currentPanel = type;
  }
}