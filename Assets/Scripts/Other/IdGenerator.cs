using System.Collections.Generic;
using UnityEngine;

namespace Other {
  public static class IdGenerator {
    private static List<int> _ids = new List<int>();

    public static int GenerateId() {
      int id = Random.Range(0, 1000);

      if (_ids == null || _ids.Count == 0) {
        id = Random.Range(0, 1000);
        _ids = new List<int>();
        _ids.Add(id);
        return id;
      }

      while (_ids.Contains(id)) {
        id = Random.Range(0, 1000);
      }

      _ids.Add(id);
      return id;
    }

    public static void RemoveId (int id) {
      if (_ids.Contains(id)) {
        _ids.Remove(id);
      }
    }
  }
}