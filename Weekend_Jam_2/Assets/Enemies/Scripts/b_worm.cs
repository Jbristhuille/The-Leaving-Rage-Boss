using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_worm : MonoBehaviour {
  public float speed;
  public int damage;

  private enemies_stats stats;
  private Rigidbody2D rb;

  // Start is called before the first frame update
  void Start() {
    rb = gameObject.GetComponent<Rigidbody2D>();
    rb.velocity = new Vector2(speed, rb.velocity.y);
    stats = gameObject.GetComponent<enemies_stats>();
  }

  // Update is called once per frame
  void Update() {
    if (stats.pv <= 0) {
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.name == "Player") {
      player_stats ps = col.gameObject.GetComponent<player_stats>();
      ps.pv -= damage;
      stats.pv -= 1;
    }
  }
}
