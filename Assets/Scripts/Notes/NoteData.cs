using System;

namespace Notes {
  public class NoteData {
    public NoteData(string preview, string description, DateTime? time) {
      PreviewText = preview;
      DescriptionText = description;
      Time = time;
    }

    public string PreviewText { get; }

    public string DescriptionText { get; }

    public DateTime? Time { get; }
  }
}