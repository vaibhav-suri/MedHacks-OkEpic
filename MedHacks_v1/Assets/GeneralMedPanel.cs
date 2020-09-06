using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using Lean.Gui;


public class GeneralMedPanel : MonoBehaviour
{
    public List<String> timelist = new List<String>();
    public UIpanelscript UIPanelScript;
      UIpanelscript UIaccess;
    public  TMP_Text  history;
    public TMP_Text nextdose;
    public int count = 0;
    public string timey;
    public GameObject infobox;
    public GameObject afteribox;
    public GameObject beforeibox;
    public bool speakerflag;
    public GameObject speakers;
  public   bool infoflag;
    public string morningt=new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,9,00,00).ToString("H:mm");
    public string eveningt= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 00, 00).ToString("H:mm");
    public string nightt= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 00, 00).ToString("H:mm");

    public GameObject[] mEn = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        infoflag = false;
        infobox.SetActive(infoflag);
        speakerflag = false;
        speakers.SetActive(speakerflag);

        UIaccess = UIPanelScript.GetComponent<UIpanelscript>();
        //print(morningt.Subtract(DateTime.Now).ToString("H:mm"));
      //  print(eveningt);
//print(nightt);
    }
    public void SpeakTime(AudioSource clippy)
    {
        clippy.Play();
    }
    public void Speaker()
    {
        speakerflag = !speakerflag;
        speakers.SetActive(speakerflag);
    }
    IEnumerator moveleft(bool flag)
    {
        Vector3 StartScale = new Vector3(0, 0, 0);
        Vector3 EndScale = new Vector3(0.8130246f, 0.594838f, 0.594838f);
       // yield return new WaitForSeconds(1);
        if (flag)
        {
            float t = 0;
            if (count < 2)
            {
                print("yes");

                while (t <= 0.4f)
                {
                    print("yesi");

                    t += Time.deltaTime;
                   infobox.transform.localScale = Vector3.Lerp(StartScale, EndScale, t);
                             // infobox.transform.position = Vector3.MoveTowards(afteribox.transform.position, beforeibox.transform.position, 1f * Time.deltaTime);

                    yield return null;
                }
                count++;
            }
            
        }
        else
        {
            float t = 0;
            if (count < 2)
            {
                while (t <= 0.4f)
                {
                    t += Time.deltaTime;
                    infobox.transform.localScale = Vector3.Lerp(EndScale, StartScale, t);
                   // infobox.transform.position = Vector3.MoveTowards(beforeibox.transform.position, afteribox.transform.position, 0.1f * Time.deltaTime);

                    yield return null;
                }
                count++;
            }
            count = 0;
        }
    }
    public void slidebox()
    {
        infoflag = !infoflag;
        infobox.SetActive(infoflag);
       // StartCoroutine(moveleft(infoflag));

    }
      public void whenon(GameObject tog)
    {
        tog.transform.GetChild(0).GetComponent<Text>().text = "Taken at " + DateTime.Now.ToString("H:mm");
        timelist.Add(DateTime.Now.ToString());
        Historylog(timelist);
    }
    public void Historylog(List<String> times)
    {
        string timestring="";
        foreach(var time in times)
        {
            timestring = timestring+ "Taken at :" + time+"\n";
          
        }
        history.text = timestring;
    }
    // Update is called once per frame
    void Update()
    {
        timey = DateTime.Now.ToString("H:mm");

        mEn[0].SetActive(UIaccess.mflag);
        mEn[1].SetActive(UIaccess.eflag);
        mEn[2].SetActive(UIaccess.nflag);
        nextdose.text="Next Dose in: " + DateTime.Parse(morningt).Subtract(DateTime.Parse(DateTime.Now.ToString("H:mm"))).ToString(@"hh\:mm");

        if (!mEn[0].GetComponent<LeanToggle>().On)
        {
           mEn[0].transform.GetChild(0).GetComponent<Text>().text ="Next Dose in: "+DateTime.Parse(morningt).Subtract(DateTime.Parse(DateTime.Now.ToString("H:mm"))).ToString(@"hh\:mm");
        }
        if (!mEn[1].GetComponent<LeanToggle>().On)
        {
            mEn[1].transform.GetChild(0).GetComponent<Text>().text = "Next Dose in: "+DateTime.Parse(eveningt).Subtract(DateTime.Parse(DateTime.Now.ToString("H:mm"))).ToString(@"hh\:mm");

        }
        if (!mEn[2].GetComponent<LeanToggle>().On)
        {
            mEn[2].transform.GetChild(0).GetComponent<Text>().text = "Next Dose in: " +DateTime.Parse(nightt).Subtract(DateTime.Parse(DateTime.Now.ToString("H:mm"))).ToString(@"hh\:mm");

        }

    }
}
