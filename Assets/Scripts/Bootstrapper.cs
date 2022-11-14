using UnityEngine;

public static class Bootstrap {
  [RuntimeInitializeOnLoadMethod]
  public static void Execute() {
    CreateObject<GameManager>();
  }

  private static void CreateObject<T>() where T : MonoBehaviour {
    if (Object.FindObjectOfType<T>() != null) {
      return;
    }

    var obj = new GameObject(typeof(T).Name);
    obj.AddComponent<T>();
  }
}