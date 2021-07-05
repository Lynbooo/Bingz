//关卡名控制
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelNameDisplay : MonoBehaviour
{
    public string text;
    float transitionSpeed = 0.01f;
    Text statsText;
    SpriteRenderer sr;
    CameraAdjuster camAdjuster;
    Vector3 pos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        statsText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        camAdjuster = FindObjectOfType<Camera>().GetComponent<CameraAdjuster>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sr.color.a < Mathf.Epsilon)
        {
            Destroy(gameObject);
            return;
        }

        // Update position and follow the camera更新位置
        pos = camAdjuster.transform.position;
        pos.z = transform.position.z;
        pos.y = 560;
        transform.position = pos;

        // Update the stats if they are even slightly seen
        Color c = sr.color;
        statsText.text = text;

        // Slowly decrease the alpha of the color调整不透明度
        if (sr.color.a > 0.01f)
        {
            c = new Color(1.0f, 1.0f, 1.0f, sr.color.a - transitionSpeed);
        }
        else if (sr.color.a <= 0.01f)
        {
            // Alpha is close to zero - mark as completely hidden
            c = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        // Update the alpha on the sprite and text
        sr.color = c;
        statsText.color = c;
    }
}
