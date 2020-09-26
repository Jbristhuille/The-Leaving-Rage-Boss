using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_grounding : MonoBehaviour {
  private player_stats ps;

  // Start is called before the first frame update
  void Start() {
    ps = GameObject.Find("Player").GetComponent<player_stats>();
  }

  // Update is called once per frame
  void Update() {
  }

  void OnTriggerEnter2D(Collider2D col) {
    ps.isGrounded = true;
  }

  void OnTriggerExit2D(Collider2D col) {
    ps.isGrounded = false;
  }
}
