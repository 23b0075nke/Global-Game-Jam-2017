﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDemo : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
    }
}
