using DG.Tweening;
using UnityEngine;

namespace Panels.Base {
  [RequireComponent(typeof(CanvasGroup))]
  public class BaseCanvasGroupWindow : MonoBehaviour {
    private CanvasGroup _canvasGroup;

    private void Awake() {
      _canvasGroup = GetComponent<CanvasGroup>();
    }

    protected void ShowPanel(bool show) {
      _canvasGroup.DOFade(show ? 1 : 0, 0.2f).OnStart(() => {
        _canvasGroup.blocksRaycasts = show;
      });
    }
  }
}