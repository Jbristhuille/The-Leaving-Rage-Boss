using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stats : MonoBehaviour {
  public bool isGrounded;
  public float speed;
  public float jumpSpeed;

  // Start is called before the first frame update
  void Start() {
    isGrounded = false;
  }

  // Update is called once per frame
  void Update() {
  }
}
