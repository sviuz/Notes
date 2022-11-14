using Other;
using Panels;

namespace Notes {
  public class DeletedNotePreview : BaseNotePreview {
    private void Start() {
      _onClickNoteButton.onClick.AddListener(Show);
    }

    private void Show() {
      PanelManager.OpenWindowDelegate?.Invoke(Enums.PanelWindow.OpenDeletedNote)
        .SetNoteDataToOpen(_noteData);
    }
  }
}