using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CG : MonoBehaviour
{
    //状态效果值
    public enum FadeStatuss
    {
        FadeIn,
        None,
        FadeOut
    }

    //设置的图片
    [SerializeField]
    public Image m_Sprite;
    //透明值
    private float m_Alpha;
    //淡入淡出状态

    private int status;

    private FadeStatuss m_Statuss;

    public FadeStatuss mStatuss
    {
        set { m_Statuss = value; }
    }
    //效更新的速度
    public float m_UpdateTime;
    //场景名称
    public string m_ScenesName;

    private float time;

    private float targetTime;

    private bool done;

    // Use this for initialization
    void Start()
    {
        time = 0;
        done = false;
        m_Statuss = FadeStatuss.FadeIn;
        m_Alpha = 0f;
        UpdateTime();
        m_Sprite = this.gameObject.GetComponent<Image>();
        m_UpdateTime = 1f;
        //默认设置为淡入效果
    }

    // Update is called once per frame
    public void Update()
    {
        //控制透明值变化
        if (m_Statuss == FadeStatuss.FadeIn)
        {
            m_Alpha += m_UpdateTime * Time.deltaTime;
        }
        else if(m_Statuss ==FadeStatuss.None)
        {
            if (gameObject.name != "Image")
            {
                time += Time.deltaTime;
                if (time >= targetTime || Input .GetKeyDown (KeyCode.Space))
                {
                    m_Statuss = FadeStatuss.FadeOut;
                }
            }
        }
        else if (m_Statuss == FadeStatuss.FadeOut)
        {
            m_Alpha -= m_UpdateTime *2* Time.deltaTime;
        }
        UpdateColorAlpha();
    }

    void UpdateColorAlpha()
    {
        //获取到图片的透明值
        Color ss = m_Sprite.color;
        ss.a = m_Alpha;
        //将更改过透明值的颜色赋值给图片
        m_Sprite.color = ss;
        //透明值等于的1的时候 转换成淡出效果
        if (m_Alpha > 1f)
        {
            m_Statuss = FadeStatuss.None;
            m_Alpha = 1f;
            if(gameObject .name .Equals("Image2"))
            {
                DontDestroyOnLoad(GameObject.Find("Egg"));
                SceneManager.LoadScene(2);
            }
        }
        else if( m_Alpha < 0.6f && m_Statuss ==FadeStatuss.FadeOut)
        {
            if (!done)
            {
                UpdateCG();
                done = true;
            }
            if (m_Alpha <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void UpdateTime()
    {
        switch (gameObject .name)
        {
            case "CG1": targetTime =1.5f;break;
            case "CG2": targetTime =1.5f;break;
            case "CG3": targetTime = 2f;break;
            case "CG4":targetTime = 1.5f;break;
            case "CG5":targetTime = 1.5f;break;
            case "CG6":targetTime = 1.5f;break;
            case "CG7": targetTime = 2f;break;
            case "CG8":targetTime = 1.5f;break;
            case "CG9":targetTime = 1.5f;break;
            case "CG10": targetTime =2f;break;
            case "CG11":targetTime = 2f;break;
            case "Image":m_Statuss = FadeStatuss.None;m_Alpha = 1; break;
            case "1": m_Alpha = 1; m_Statuss = FadeStatuss.FadeOut;m_UpdateTime /= 50; break;
            default:break;

        }
    }
    void UpdateCG()
    {
        switch (gameObject.name)
        {
            case "CG1": GameObject.Find(IDRegister.CANVAS).transform.Find("CG2").gameObject.SetActive(true); break;
            case "CG2": GameObject.Find(IDRegister.CANVAS).transform.Find("CG3").gameObject.SetActive(true); break;
            case "CG3": GameObject.Find(IDRegister.CANVAS).transform.Find("CG4").gameObject.SetActive(true); break;
            case "CG4": GameObject.Find(IDRegister.CANVAS).transform.Find("CG5").gameObject.SetActive(true); break;
            case "CG5": GameObject.Find(IDRegister.CANVAS).transform.Find("CG6").gameObject.SetActive(true); break;
            case "CG6": GameObject.Find(IDRegister.CANVAS).transform.Find("CG7").gameObject.SetActive(true); break;
            case "CG7": GameObject.Find(IDRegister.CANVAS).transform.Find("CG8").gameObject.SetActive(true); break;
            case "CG8": GameObject.Find(IDRegister.CANVAS).transform.Find("CG9").gameObject.SetActive(true); break;
            case "CG9": GameObject.Find(IDRegister.CANVAS).transform.Find("CG10").gameObject.SetActive(true); break;
            case "CG10": GameObject.Find(IDRegister.CANVAS).transform.Find("CG11").gameObject.SetActive(true); break;
            case "CG11": GameManager.instance.startFly = true; GameManager.instance.time = 4.5f;GameManager.instance.ap.Stop(Camera.main.gameObject);
                GameManager.instance.ap.AddAudioClip(Camera.main.gameObject, "Audio/tw086"); GameManager.instance.ap.Play(Camera.main.gameObject);
                 GameObject.Find(IDRegister.CANVAS).transform.Find("Image").GetComponent <CG>().mStatuss=FadeStatuss.FadeOut; break;
            default: break;

        }
    }

}
