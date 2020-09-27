using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    public bool v = false;
    private GameObject vvv;

    // Start is called before the first frame update
    void Start()
    {
      vvv = GameObject.Find("Canvas");
    }

  // Update is called once per frame
  void Update()
  {
    if (v) {
      gameObject.transform.Find("victory").gameObject.SetActive(true);
    }
  }
}
