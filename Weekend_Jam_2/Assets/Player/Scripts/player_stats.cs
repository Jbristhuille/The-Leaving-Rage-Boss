using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stats : MonoBehaviour {
  public bool isGrounded;
  public float speed;
  public float jumpSpeed;
  public float slashCd;
  public float slashDuration;
  public int damage;
  public int pv;

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {
    if (pv <= 0) { // Player death
      Destroy(gameObject);
    }
  }
}
