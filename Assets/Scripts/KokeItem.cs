using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KokeItem : MonoBehaviour
{
    public int a;   //切り替え番号

    public AudioSource audioSource;
    public AudioClip soundeat;
    public AudioClip soundgauge;

    public Material ItemMaterial;
    public Texture KokeOnItemTex;
    public Texture KokeOFFItemTex;

    public Image StoryImage;
    public GameObject DeleteButton;

    bool Scene1;
    bool Scene2;
    bool Scene3;
    bool Scene4;
    void Start()
    {
        a = 0;
    }
    void OnTriggerEnter(Collider other) //衝突時に実行されるメソッド
    {
        if (other.name == "Snali")
        {
            a = 1;
            Scene1 = true;
        }
    }
    void Update()
    {
        
    }
    void Item_flow()
    {
        switch (a)
        {
            case 1:
                Debug.Log("シーン1");

                break;
            case 2:
                Debug.Log("シーン2");

                break;
            case 3:
                Debug.Log("シーン3");

                break;
            case 4:
                Debug.Log("シーン4");

                break;
        }
    }
    public void OnClick()   //ボタンを押したとき
    {

    }
}
