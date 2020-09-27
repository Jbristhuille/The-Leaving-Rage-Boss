using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_trigger : MonoBehaviour
{
  public GameObject boss;
  public GameObject bossSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerExit2D(Collider2D col) {
      if (col.gameObject.tag == "Player") {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        Instantiate(boss, bossSpawn.transform.position, Quaternion.identity);
      }
    }
}
