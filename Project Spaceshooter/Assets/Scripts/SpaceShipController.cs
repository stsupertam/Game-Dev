﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            this.gameObject.transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * 3f);
        }
    }
}
