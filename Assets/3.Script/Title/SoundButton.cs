using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Button soundOn;
    public Button soundOff;
    private void Start()
    {
        SoundOn();
    }
    public void SoundOff()
    {
        soundOn.gameObject.SetActive(false);
        soundOff.gameObject.SetActive(true);
    }
    public void SoundOn()
    {
        soundOn.gameObject.SetActive(true);
        soundOff.gameObject.SetActive(false);
    }
}
