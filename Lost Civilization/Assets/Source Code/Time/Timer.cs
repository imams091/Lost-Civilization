using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timertext;

    [Header("Timer Settings")]
    public float curentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public Timerformats format;
    private Dictionary<Timerformats, string> timeFormats = new Dictionary<Timerformats, string>();

    private void Start()
    {
        timeFormats.Add(Timerformats.Whole, "0");
        timeFormats.Add(Timerformats.TenthDecimal, "0.0");
        timeFormats.Add(Timerformats.HundrethsDecimal, "0.00");
    }

    private void Update()
    {
        curentTime = countDown ? curentTime -= Time.deltaTime : curentTime += Time.deltaTime;

        if(hasLimit && ((countDown && curentTime <= timerLimit) || (!countDown && curentTime >= timerLimit)))
        {
            curentTime = timerLimit;
            setTimerText();
            timertext.color = Color.red;
            enabled = false;
        }
        setTimerText();
     }

    private void setTimerText()
    {
        timertext.text = curentTime.ToString();
        timertext.text = hasFormat ? curentTime.ToString(timeFormats[format]) : curentTime.ToString();
    }

    public enum Timerformats
    {
        Whole,
        TenthDecimal,
        HundrethsDecimal
    }
}
