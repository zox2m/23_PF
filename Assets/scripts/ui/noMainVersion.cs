using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noMainVersion : MonoBehaviour
{
    GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.hide(UI_PAGE.CREDIT_BAR);
        UIManager.Instance.hide(UI_PAGE.MAIN_MENU);

        this.room = GameObject.Find("Main").transform.Find("playroom").gameObject;
        this.room.SetActive(true);
    }
}
