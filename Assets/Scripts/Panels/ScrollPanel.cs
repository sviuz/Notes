using System;
using DG.Tweening;
using Other;
using UnityEngine;
using static Other.Enums;

namespace Panels {
  public class ScrollPanel : MonoBehaviour {
    public static Action<NavigationType> Swipe;

    [SerializeField]
    private float _swipeTime = 0.3f;
    
    private Transform _rect;

    private void Awake() {
      _rect = GetComponent<Transform>();
      Swipe += SwipePanel;
    }

    private void SwipePanel(NavigationType type) {
      float xPosition = type.GetPanelType();
      _rect.DOLocalMoveX(xPosition, _swipeTime);
    }
  }
}