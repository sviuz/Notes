using Notes;
using Time;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.Base {
  public class BaseNoteWindow : BaseCanvasGroupWindow {
    [SerializeField]
    private TMP_InputField _inputNoteNameText;
    [SerializeField]
    private TMP_InputField _inputNoteDescriptionText;
    [SerializeField]
    private Button _createNoteButton;
    [SerializeField]
    private Button _saveEditNoteButton;
    [SerializeField]
    private Button _editButton;
    [SerializeField]
    private Button _closePanelButton;

    private void Start() {
      ClearInputFields();
      ShowPanel(false);

      SubscribeButtons();
    }

    private void SubscribeButtons() {
      _createNoteButton.onClick.AddListener(AddNote);
      _closePanelButton.onClick.AddListener(ClosePanelButtonClick);
      _editButton.onClick.AddListener(SetEditNote);
    }

    private void AddNote() {
      NoteData noteData =
        new(_inputNoteNameText.text, _inputNoteDescriptionText.text, TimeGetter.GetNoteTime?.Invoke());
      NotesScrollPanel.AddNote.Invoke(noteData);

      ClearInputFields();
      ShowPanel(false);
    }

    private void ClosePanelButtonClick() {
      ShowPanel(false);
      // ClearInputFields();
    }

    public void Show() {
      ShowPanel(true);
    }

    public void ClearInputFields() {
      _inputNoteNameText.text = string.Empty;
      _inputNoteDescriptionText.text = string.Empty;
    }

    protected void SetAddNote() {
      _editButton.gameObject.SetActive(false);
      _createNoteButton.gameObject.SetActive(true);
      _inputNoteNameText.interactable = true;
      _inputNoteDescriptionText.interactable = true;
    }

    protected void SetOpenNote() {
      _createNoteButton.gameObject.SetActive(false);
      _editButton.gameObject.SetActive(true);
      _inputNoteNameText.interactable = false;
      _inputNoteDescriptionText.interactable = false;
      _saveEditNoteButton.gameObject.SetActive(false);
    }

    private void SetEditNote() {
      _inputNoteNameText.interactable = true;
      _inputNoteDescriptionText.interactable = true;
      _saveEditNoteButton.gameObject.SetActive(true);
      _createNoteButton.gameObject.SetActive(false);
    }

    protected void SetNoteData(NoteData noteData) {
      _inputNoteNameText.text = noteData.PreviewText;
      _inputNoteDescriptionText.text = noteData.DescriptionText;
    }
  }
}