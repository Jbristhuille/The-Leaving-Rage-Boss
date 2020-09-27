using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_boss : MonoBehaviour {
  public GameObject firePoint;
  public GameObject firePrefab;

  public float couldownAction;
  public float speed;
  public int damage;

  private Rigidbody2D rb;
  private int action = 0;
  private float cd;
  private bool ready = true;
  private enemies_stats stats;

  // Start is called before the first frame update
  void Start() {
    rb = gameObject.GetComponent<Rigidbody2D>();
    cd = couldownAction;
    stats = gameObject.GetComponent<enemies_stats>();
  }

  // Update is called once per frame
  void Update() {
    if (stats.pv <= 0)
      Destroy(gameObject);

    if (cd <= 0 && ready) {
      ready = false;
      rb.velocity = new Vector2(speed*gameObject.transform.localScale.x, 0);
    } else {
      cd -= Time.deltaTime;
    }
  }

  void OnTriggerEnter2D(Collider2D col) {
    rb.velocity = new Vector2(0, 0);
    Vector3 newScale = gameObject.transform.localScale;
    newScale.x = newScale.x * -1;
    gameObject.transform.localScale = newScale;
    ready = true;
    cd = couldownAction;

    if (col.gameObject.tag == "Player") {
      player_stats ps = GameObject.Find("Player").GetComponent<player_stats>();

      if (!ps.noDamage) {
        ps.pv -= damage;
        ps.noDamage = true;
        ps.damageCd = ps.noDamageTimer;
      }
    }
  }
}
