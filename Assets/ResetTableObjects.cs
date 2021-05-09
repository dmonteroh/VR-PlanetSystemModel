using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTableObjects : MonoBehaviour
{
    public GameObject Sun;
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Moon;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetTableObjects()
    {
        Sun.transform.localPosition = new Vector3(-0.403f, 0.1383775f, -0.03000014f);
        Mercury.transform.localPosition = new Vector3(-0.298f, 0.1383775f, -0.02700014f);
        Venus.transform.localPosition = new Vector3(-0.192f, 0.1383775f, -0.024f);
        Earth.transform.localPosition = new Vector3(-0.082f, 0.1383775f, -0.022f);
        Moon.transform.localPosition = new Vector3(0.539f, 0.1383775f, -0.022f);
        Mars.transform.localPosition = new Vector3(0.021f, 0.1383775f, -0.022f);
        Jupiter.transform.localPosition = new Vector3(0.119f, 0.1383775f, -0.022f);
        Saturn.transform.localPosition = new Vector3(0.218f, 0.1383775f, -0.022f);
        Uranus.transform.localPosition = new Vector3(0.329f, 0.1383775f, -0.022f);
        Neptune.transform.localPosition = new Vector3(0.433f, 0.1383775f, -0.022f);
    }
}
