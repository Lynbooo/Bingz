using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bombUI : MonoBehaviour
{
    public int startBombQuantity;
    public Text bombQuantity;
    public static int CurrentBombQuantity;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBombQuantity = startBombQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        bombQuantity.text = "x" + CurrentBombQuantity.ToString();
    }
}
