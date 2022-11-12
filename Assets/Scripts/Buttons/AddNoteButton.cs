using Other;
using Panels;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons {
  public class AddNoteButton : MonoBehaviour {
    private Button _addNoteButton;

    private void Awake() {
      _addNoteButton = GetComponent<Button>();
    }

    private void Start() {
      _addNoteButton.onClick.AddListener(ShowAddNoteWindow);
    }

    private static void ShowAddNoteWindow() {
      PanelManager.OpenWindowDelegate?.Invoke(Enums.PanelWindow.AddNote);
    }
  }
}