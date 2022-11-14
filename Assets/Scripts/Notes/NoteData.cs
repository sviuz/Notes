using System;

namespace Notes {
  public class NoteData {
    public NoteData(int id, string preview, string description, DateTime? time) {
      Id = id;
      PreviewText = preview;
      DescriptionText = description;
      Time = time;
    }
    
    public NoteData(string preview, string description, DateTime? time) {
      PreviewText = preview;
      DescriptionText = description;
      Time = time;
    }

    public int Id { get; }
    
    public string PreviewText { get; }

    public string DescriptionText { get; }

    public DateTime? Time { get; }
  }
}