using System;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
  private void Awake() {
    Application.targetFrameRate = 300;
  }
}