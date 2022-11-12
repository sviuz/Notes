using System;
using Notes;
using UnityEngine;
using static Other.Enums;

namespace Panels {
  public class NotesScrollPanel : MonoBehaviour {
    public static Action<NoteData> AddNote;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private NotePreviewObject _prefab;
    [SerializeField]
    private NavigationType _type;

    private void Awake() {
      Sub();
    }

    private void OnDestroy() {
      Sub(false);
    }

    private void Sub(bool sub = true) {
      if (sub) {
        AddNote += CreateNote;
        return;
      }
      AddNote -= CreateNote;
    }
    
    private void CreateNote(NoteData noteData) {
      Debug.Log("adding note");
      Instantiate(_prefab, _target).SetDataOnCreate(noteData);
      Debug.Log(noteData.Time.ToString());
    }
  }
}