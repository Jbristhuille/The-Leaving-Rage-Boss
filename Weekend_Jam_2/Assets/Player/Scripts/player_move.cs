using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {
  private Rigidbody2D rb;
  private player_stats ps;

  // Start is called before the first frame update
  void Start() {
    rb = gameObject.GetComponent<Rigidbody2D>();
    ps = gameObject.GetComponent<player_stats>();
  }

  // Update is called once per frame
  void Update() {
    rb.velocity = new Vector2((Input.GetAxis("horizontal")*ps.speed), rb.velocity.y); // Horizontal movements



    if (Input.GetAxis("jump") > 0 && ps.isGrounded) { // Jump
      rb.velocity = new Vector2(rb.velocity.x, 0);
      rb.AddForce(new Vector2(0, ps.jumpSpeed));

      if (ps.isGrounded == true)
        ps.isGrounded = false;
    }
  }
}
