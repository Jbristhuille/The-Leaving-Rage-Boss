using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_object : MonoBehaviour {
    private int damage = 1;
    private float fireSpeed = 15;
    private float lifetime = 2;
    private Rigidbody2D rb;
    private player_stats ps;

    // Start is called before the first frame update
    void Start() {
      ps = GameObject.Find("Player").GetComponent<player_stats>();
      rb = gameObject.GetComponent<Rigidbody2D>();
      int direction = GameObject.Find("Final_boss").transform.localScale.x > 0 ? 1 : -1;

      rb.velocity = new Vector2(fireSpeed * direction, 0);
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
      if (col.gameObject.tag == "Player") {
        player_stats ps = GameObject.Find("Player").GetComponent<player_stats>();
        ps.pv -= damage;
        Destroy(gameObject);
      }
    }
}
