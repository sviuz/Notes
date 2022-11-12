using Other;
using Panels;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Notes {
  public class NotePreviewObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    [SerializeField]
    private Button _onClickNoteButton;
    [SerializeField]
    private TMP_Text _labelText;

    private NoteData _noteData;

    public void SetDataOnCreate(NoteData noteData) {
      _noteData = noteData;
      _labelText.text = _noteData.PreviewText;
    }

    private void Start() {
      _onClickNoteButton.onClick.AddListener(Show);
    }

    private void Show() {
      PanelManager.OpenWindowDelegate?.Invoke(Enums.PanelWindow.OpenNote).SetNoteDataToOpen(_noteData);
    }

    public void OnDrag(PointerEventData eventData) {
    }

    public void OnBeginDrag(PointerEventData eventData) {
    }

    public void OnEndDrag(PointerEventData eventData) {
    }
  }
}