using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_damage : MonoBehaviour {
  private player_stats ps;

  // Start is called before the first frame update
  void Start() {
    ps = GameObject.Find("Player").GetComponent<player_stats>();
  }

  // Update is called once per frame
  void Update() {
  }

  void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "enemy") {
      col.gameObject.GetComponent<enemies_stats>().pv -= ps.damage;
    }
  }
}
