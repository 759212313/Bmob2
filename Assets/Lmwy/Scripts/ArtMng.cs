using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArtMng : MonoBehaviour {

    public ArtItem[] lists;

    public void Refresh(List<ContentMode> modes)
    {
        for (int i = 0; i < lists.Length; i++)
        {
            
            if (i < modes.Count)
            {
                ContentMode item = modes[i];
                lists[i].gameObject.SetActive(true);
                lists[i].name.text = item.title;
                lists[i].title = item.title;
                lists[i].content = item.content;
            }
            else {
                lists[i].gameObject.SetActive(false);
            }
        }
    }
}
