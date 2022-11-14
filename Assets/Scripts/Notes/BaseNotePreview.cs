using DG.Tweening;
using Other;
using Panels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Notes {
  public class BaseNotePreview : MonoBehaviour {
    [SerializeField]
    protected Button _onClickNoteButton;
    [SerializeField]
    private TMP_Text _labelText;
    [SerializeField]
    protected Transform _draggableNote;

    protected NoteData _noteData;
    private CanvasGroup _canvasGroup;

    private void Awake() {
      _canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void SetDataOnCreate (NoteData noteData) {
      _noteData = noteData;
      _labelText.text = _noteData.PreviewText;
    }
    
    protected void Fade() {
      _canvasGroup.DOFade(0, 0.2f).OnComplete(OnFadeComplete);
    }

    private void OnFadeComplete() {
      if (_draggableNote.localPosition.x > 0) {
        Debug.Log("delete");
        NotesManager.RemoveNote?.Invoke(_noteData);
      } else {
        Debug.Log("complete");
      }

      IdGenerator.RemoveId(_noteData.Id);
      TopBar.UpdateText?.Invoke();

      Destroy(gameObject);
    }

  }
}