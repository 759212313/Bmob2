using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArtItem : MonoBehaviour {

    public Text name;

    public string title;
    public string content;
    public GameObject dPage;

    public void ClickItem()
    {
        dPage.gameObject.SetActive(true);
        Content data= dPage.GetComponent<Content>();
        data.title.text = title;
        data.content.text = content;
    }
}
