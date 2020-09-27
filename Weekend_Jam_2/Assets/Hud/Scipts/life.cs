using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour {
  public int cond = 0;

  private player_stats ps;

  // Start is called before the first frame update
  void Start() {
    ps = GameObject.Find("Player").GetComponent<player_stats>();
  }

  // Update is called once per frame
  void Update() {
    if (ps.pv < cond) {
      gameObject.SetActive(false);
    }
  }
}
