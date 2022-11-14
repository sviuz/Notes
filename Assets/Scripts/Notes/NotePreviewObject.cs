using System;
using Other;
using Panels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Notes {
  [RequireComponent(typeof(CanvasGroup))]
  public class NotePreviewObject : BaseNotePreview, IDragHandler, IBeginDragHandler,
    IEndDragHandler {
    private Vector2 _beginPosition;
    private bool _alive = true;

    
    public void OnDrag (PointerEventData eventData) {
      _draggableNote.localPosition += new Vector3(eventData.delta.x, 0);

      if (!(Math.Abs(_draggableNote.localPosition.x) > 650) || !_alive)
        return;

      _alive = false;

      Fade();
    }

    private void Start() {
      _onClickNoteButton.onClick.AddListener(Show);
    }

    private void Show() {
      PanelManager.OpenWindowDelegate?.Invoke(Enums.PanelWindow.OpenNote)
        .SetNoteDataToOpen(_noteData);
    }

    public void OnBeginDrag (PointerEventData eventData) {
      _beginPosition = _draggableNote.localPosition;
    }

    public void OnEndDrag (PointerEventData eventData) {
      if (!(Math.Abs(_draggableNote.localPosition.x) > 650)) {
        _draggableNote.localPosition = _beginPosition;
      }
    }
  }
}