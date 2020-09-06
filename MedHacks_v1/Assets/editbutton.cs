using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editbutton : MonoBehaviour
{
    public GameObject panelhis;
    public bool openflag;
    // Start is called before the first frame update
    void Start()
    {
        openflag = false;
    }

    public void History()
    {
        openflag = true;

    }
    public void Close()
    {
        openflag = false;
    }
    // Update is called once per frame
    void Update()
    {
        panelhis.SetActive(openflag);
    }
}
