using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIHealthBar instance { get; private set; }

    public UnityEngine.UI.Image mask;
    float originalsize;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalsize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal, originalsize * value);
    }
}
