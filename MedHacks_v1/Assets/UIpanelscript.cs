using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Lean.Gui;
using TMPro;

public class UIpanelscript : MonoBehaviour
{
    public GameObject morning;
    public GameObject evening;
    public GameObject night;
    public bool mflag;
    public bool eflag;
    public bool nflag;
    public TMP_Text NameText;
    public TMP_Text sourcetext;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        NameText.text = sourcetext.text;
        mflag = morning.GetComponent<LeanToggle>().On;
        eflag = evening.GetComponent<LeanToggle>().On;
        nflag = night.GetComponent<LeanToggle>().On;
    }
}
