using System;
using Notes;
using Other;
using Panels.Base;

namespace Panels {
  public class PanelWindow : BaseNoteWindow {
    public void SetStateWindow(Enums.PanelWindow type) {
      switch (type) {
        case Enums.PanelWindow.AddNote:
          SetAddNote();
          break;
        case Enums.PanelWindow.OpenNote:
          SetOpenNote();
          break;
        case Enums.PanelWindow.EditNote:
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(type), type, null);
      }
    }
    
    public void SetNoteDataToOpen(NoteData noteData) {
      SetNoteData(noteData);
    }
  }
}