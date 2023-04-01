using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimySponeBullit : MonoBehaviour {
	public GameObject  bullitPrefab;
	public Transform sponePoint;
	// Use this for initialization
	void Start () {
		InvokeRepeating("BullitSopne", 1f, 0.8f);
	}
	public void BullitSopne()
    {
		Instantiate(bullitPrefab, sponePoint.transform.position, sponePoint.transform.rotation);
    }
}
