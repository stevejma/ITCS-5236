using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour {

    [SerializeField] private GameObject unit1;
    [SerializeField] private GameObject unit2;
    [SerializeField] private GameObject unit3;
    [SerializeField] private GameObject unit4;

    private UnitController unit1Mov;
    private UnitController unit2Mov;
    private UnitController unit3Mov;
    private UnitController unit4Mov;

    // Use this for initialization
    void Start () {

        unit1Mov = unit1.GetComponent<UnitController>();
        unit2Mov = unit2.GetComponent<UnitController>();
        unit3Mov = unit3.GetComponent<UnitController>();
        unit4Mov = unit4.GetComponent<UnitController>();
	
	unit1Mov.enabled = false;
	unit2Mov.enabled = false;
	unit3Mov.enabled = false;
	unit4Mov.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
            unit1Mov.enabled = true;
            unit2Mov.enabled = false;
            unit3Mov.enabled = false;
            unit4Mov.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            unit2Mov.enabled = true;
            unit1Mov.enabled = false;
            unit3Mov.enabled = false;
            unit4Mov.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            unit3Mov.enabled = true;
            unit1Mov.enabled = false;
            unit2Mov.enabled = false;
            unit4Mov.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            unit4Mov.enabled = true;
            unit1Mov.enabled = false;
            unit2Mov.enabled = false;
            unit3Mov.enabled = false;
        }
    }
}
