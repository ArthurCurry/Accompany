using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool toDo;
    private bool once;

    private XmlReader instance;
    private Dialog dialog;
    private GameObject player;
    private string s;
    private int x;
    private int count;
    private bool toPause;
    private bool onlyOne;
    private bool level9;
    private bool one;
    private bool level11;
    private bool level13;
    private bool toStop;

    private bool dontDestroy;

    // Use this for initialization
    void Start()
    {
        m_Sprite = this.gameObject.GetComponent<Image>();
        m_Alpha = 0f;
        m_UpdateTime = 1f;
        //默认设置为淡入效果
        m_Statuss = FadeStatuss.FadeIn;
    }

    // Update is called once per frame
    public void Update()
    {
        //控制透明值变化
        if (m_Statuss == FadeStatuss.FadeIn)
        {
            m_Alpha += m_UpdateTime * Time.deltaTime;
        }
        else if (m_Statuss == FadeStatuss.FadeOut)
        {
            m_Alpha -= m_UpdateTime * Time.deltaTime;
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
            m_Statuss = FadeStatuss.FadeOut;
            m_Alpha = 1f;
        }
        else if (m_Alpha < 0)
        {
            if (!dontDestroy)
            {
                Destroy(this.gameObject);
            }
        }

    }

    void UpdateTime()
    {
        if (toDo)
        {
            time += Time.deltaTime;
            if (time >= 1f)
                toDo = false;
        }
    }

    void Dialog()
    {
        if (time >= 1f && once && !toDo)
        {
            if (!onlyOne)
            {
                if (this.gameObject.name.Equals("CG11(Clone)"))
                {
                    InitAttribution("第六关触发3");
                    InitDialog();
                    time = 0f;
                    toPause = true;
                    onlyOne = true;
                }
                else if (this.gameObject.name.Equals("CG14(Clone)"))
                {
                    InitAttribution("第八关结束1");
                    InitDialog();
                    time = 0f;
                    toPause = true;
                    onlyOne = true;
                }
            }
        }
        else if (level9 && !one)
        {
            InitAttribution("第五关结束2");
            InitDialog();
            toPause = true;
            onlyOne = true;
            one = true;
        }
        else if (level11 && !one)
        {
            InitAttribution("第六关触发3");
            InitDialog();
            toPause = true;
            onlyOne = true;
            one = true;
        }
        else if (level13 && !one)
        {
            InitAttribution("第七关结束CG1");
            InitDialog();
            toPause = true;
            onlyOne = true;
            one = true;
        }
    }

    void ToStopEffect()
    {
        if (toStop)
        {
            if (!(GameObject.Find("Canvas").GetComponent<ChangeEffect>().M_State == ChangeEffect.State.none || GameObject.Find("Canvas").GetComponent<ChangeEffect>().M_State == ChangeEffect.State.FadeIn))
            {
                GameObject.Find("Canvas").GetComponent<ChangeEffect>().M_State = ChangeEffect.State.none;
            }
        }
    }

    void InitDialog()
    {
        dialog = new Dialog();
        dialog.ID = dialog.Split(instance.GetXML(s, 0), 0);
        dialog.showDialog(dialog.JudgeD(dialog.ID));
        dialog.setDialogText(dialog.Split(instance.GetXML(s, 0), 1));
    }

    void InitAttribution(string n) // 赋予触发剧情的属性
    {
        x = 1;
        s = n;
        count = instance.getCount(s, 0);
        instance.SetIndex(0);
    }

    void ShowDialog()
    {
        if (toPause)
        {
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    instance.SetIndex(x);
                    if (!JudgeD(dialog.ID))
                    {
                        dialog.DestoryDiaLog();
                        dialog.ID = dialog.Split(instance.GetXML(s, 0), 0);
                        dialog.showDialog(dialog.JudgeD(dialog.ID));
                    }
                    dialog.setDialogText(dialog.Split(instance.GetXML(s, 0), 1));
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                x = 0;
            }
        }

    }
    public bool JudgeD(string name)  //判断对话框的ID
    {
        if (name.Equals(dialog.Split(instance.GetXML(s, 0), 0)))
        {
            return true;
        }
        else return false;
    }
}
