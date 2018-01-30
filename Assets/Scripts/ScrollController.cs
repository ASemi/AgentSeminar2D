using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour {

    [SerializeField]
    RectTransform prefab = null;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 15; i++)
        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
