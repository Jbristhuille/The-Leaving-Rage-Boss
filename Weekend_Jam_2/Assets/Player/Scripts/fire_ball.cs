using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ball : MonoBehaviour {
  private player_stats ps;
  private float lifetime;
  private Rigidbody2D rb;

  // Start is called before the first frame update
  void Start() {
    ps = GameObject.Find("Player").GetComponent<player_stats>();
    rb = gameObject.GetComponent<Rigidbody2D>();
    int direction = GameObject.Find("Player").transform.localScale.x > 0 ? 1 : -1;

    rb.velocity = new Vector2(ps.fireSpeed * direction, 0);
    lifetime = ps.fireCd;
  }

  // Update is called once per frame
  void Update() {
    if (lifetime > 0) {
      lifetime -= Time.deltaTime;
    } else {
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "enemy") {
      col.gameObject.GetComponent<enemies_stats>().pv -= ps.damage;
      Destroy(gameObject);
    }
  }
}
