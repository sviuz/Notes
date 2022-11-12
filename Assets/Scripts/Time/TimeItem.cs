using System;
using TMPro;
using UnityEngine;

namespace Time {
  public class TimeItem : MonoBehaviour {
    [SerializeField]
    private TMP_Text _text;

    public void SetTime(string time) {
      _text.text = time;
    }
    
    public int GetTime() => int.Parse(_text.text);
  }
}