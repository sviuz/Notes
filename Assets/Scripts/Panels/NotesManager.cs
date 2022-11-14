using System;
using System.Collections.Generic;
using Notes;
using UnityEngine;

namespace Panels {
  public class NotesManager : MonoBehaviour {
    private static List<NoteData> _notes = new List<NoteData>();
    public static Action<NoteData> AddNote;
    public static Action<NoteData> RemoveNote;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private NotePreviewObject _prefab;

    private void Awake() {
      Sub();
    }

    private void OnDestroy() {
      Sub(false);
    }

    private void Sub (bool sub = true) {
      if (sub) {
        AddNote += CreateNote;
        AddNote += AddNoteToList;

        RemoveNote += RemoveFromList;
        return;
      }

      AddNote -= CreateNote;
      AddNote -= AddNoteToList;

      RemoveNote -= RemoveFromList;
    }

    private void CreateNote (NoteData noteData) {
      Instantiate(_prefab, _target).SetDataOnCreate(noteData);
    }

    private static void AddNoteToList (NoteData noteData) {
      _notes.Add(noteData);
    }

    private static void RemoveFromList (NoteData noteData) {
      _notes.Remove(noteData);
    }

    public static int GetTasksCount()
      => _notes.Count;
  }
}