using Other;
using UnityEngine;

namespace Time {
  public class TimeSetter : MonoBehaviour {
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private TimeItem _prefab;
    [SerializeField]
    private Enums.TimeType _timeType;

    private void Awake() {
      SetTimeByType();
    }

    private void SetTimeByType() {
      int timeCounter = 0;
      for (int i = 0; i < (int)_timeType; i++) {
        var obj = Instantiate(_prefab,_target);
        obj.SetTime(SetTime(++timeCounter));
        obj.name = $"TimeItem_{i+1}";
      }
    }

    private string SetTime(int value) {
      if (value <10) {
        return $"0{value}";
      }

      return value.ToString();
    }
  }
}