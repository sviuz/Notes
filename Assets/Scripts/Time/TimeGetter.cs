using System;
using UnityEngine;

namespace Time {
  public class TimeGetter : MonoBehaviour {
    public static Func<DateTime> GetNoteTime;
    [SerializeField]
    private GameObject _hoursObject;
    [SerializeField]
    private GameObject _minutesObject;

    private void Awake() {
      Sub();
    }

    private void OnDestroy() {
      Sub(false);
    }

    private void Sub(bool sub = true) {
      if (sub) {
        GetNoteTime += GetScheduledTime;
        return;
      }
      GetNoteTime -= GetScheduledTime;
    }

    private DateTime GetScheduledTime() {
      int hours = _hoursObject.transform.GetChild(0).GetComponent<TimeItem>().GetTime();
      int minutes = _minutesObject.transform.GetChild(0).GetComponent<TimeItem>().GetTime();
      return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hours, minutes, 0);
    }
  }
}