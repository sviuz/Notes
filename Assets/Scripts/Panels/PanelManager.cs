using Other;
using UnityEngine;

namespace Panels {
  public delegate PanelWindow OpenWindow(Enums.PanelWindow type);
  public class PanelManager : MonoBehaviour {
    public static OpenWindow OpenWindowDelegate;

    [SerializeField]
    private PanelWindow _window;

    private void Awake() {
      Sub();
    }

    private void Sub(bool sub = true) {
      if (sub) {
        OpenWindowDelegate += Open;
        return;
      }
      OpenWindowDelegate -= Open;
    }

    private PanelWindow Open(Enums.PanelWindow type) {
      _window.ClearInputFields();
      _window.Show();
      _window.SetStateWindow(type);

      return _window;
    }
  }
}