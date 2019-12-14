using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEffect : MonoBehaviour {

    public enum o_status
    {
        start,
        none,
        end
    }
    public o_status game;

    private RawImage rawImage;

    private float fadeTime;
    public float FadeTime
    {
        set { fadeTime = value; }
    }

    public enum State
    {
        FadeIn,
        none,
        FadeOut
    }

    public State m_State;
    public State M_State
    {
        get { return m_State; }
        set { m_State = value; }
    }

    // Use this for initialization
    void Start () {
        game = o_status.start;
        rawImage = GameObject.Find(IDRegister.CANVAS).transform.Find("RawImage").GetComponent<RawImage>();
        fadeTime = 1.5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_State == State.FadeIn)
        {
            EndScene();
            if (rawImage.color.a >= 0.98f && game == o_status.end)
            {
            }
        }
        if (m_State == State.FadeOut)
        {
            StartScene();
            if(rawImage.color.a <= 0.8f&& game == o_status .start)
            {
                game = o_status.none;
            }
        }
    }

    private void FadeOut() //淡出
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeTime * Time.deltaTime);
    }

    private void FadeIn() //淡入
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeTime * Time.deltaTime);
    }

    void StartScene()
    {
        FadeOut();
        if(rawImage.color.a <= 0.15f)
        {
        }
        if (rawImage.color.a <= 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;            
            m_State = State.none;
        }
    }

    void EndScene()
    {
        rawImage.enabled = true;
        FadeIn();
        if (rawImage.color.a >= 0.95f)
        {
            this.fadeTime = 1.5f;
            rawImage.color = Color.black;
            m_State = State.FadeOut;
        }
    }
}
