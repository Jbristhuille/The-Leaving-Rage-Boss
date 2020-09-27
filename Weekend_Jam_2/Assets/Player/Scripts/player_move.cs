using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {
  private Rigidbody2D rb;
  private player_stats ps;
  private float direction;
  private Vector3 newScale;
  private Animator animation;

  // Start is called before the first frame update
  void Start() {
    rb = gameObject.GetComponent<Rigidbody2D>();
    ps = gameObject.GetComponent<player_stats>();
    animation = gameObject.GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {
    direction = Input.GetAxis("horizontal");

    /* Player orientation */
    newScale = gameObject.transform.localScale;

    if (direction < 0) {
      newScale.x = -1;
    } else if (direction > 0) {
      newScale.x = 1;
    }

    gameObject.transform.localScale = newScale;
    /***/

    if (!ps.onDash) {
      animation.SetFloat("speed", Mathf.Abs(direction));
      rb.velocity = new Vector2(direction*ps.speed, rb.velocity.y); // Horizontal movements
    }


    /* Jump */
    if (Input.GetAxis("jump") > 0 && ps.isGrounded) {
      rb.velocity = new Vector2(rb.velocity.x, 0);
      rb.AddForce(new Vector2(0, ps.jumpSpeed));

      if (ps.isGrounded == true)
        ps.isGrounded = false;
    }
    /***/
  }
}
