using System;
using Panels;
using TMPro;
using UnityEngine;

public class TopBar : MonoBehaviour {
  private const string ACTIVE_TASKS = "Active tasks: $";
  private const string COMPLETED_TASKS = "Completed tasks: $";
  public static Action UpdateText;
  [SerializeField]
  private TMP_Text _availableTasksText;
  [SerializeField]
  private TMP_Text _completedTasksText;

  private void Awake() {
    Sub();
  }

  private void Start() {
    UpdateText?.Invoke();
  }

  private void OnDestroy() {
    Sub(false);
  }

  private void Sub (bool sub = true) {
    if (sub) {
      UpdateText += SetTopBarText;
      return;
    }
    UpdateText -= SetTopBarText;
  }

  private void SetTopBarText() {
    int availableTasksCount = NotesManager.GetTasksCount();
    int completedTasksCount = -1;
    _availableTasksText.text = ACTIVE_TASKS.Replace("$", availableTasksCount.ToString());
    _completedTasksText.text = COMPLETED_TASKS.Replace("$", completedTasksCount.ToString());
  }
}