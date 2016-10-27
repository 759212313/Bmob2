using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Content : MonoBehaviour {

    public Text title;
    public Text content;

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
