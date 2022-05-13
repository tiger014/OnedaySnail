using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvas : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject TutorialMove;
    public GameObject Panel;
    public GameObject Button;

    //ゲーム開始時に実行される
    void Start()
    {
        //パネルを隠す
        Canvas.SetActive(false);
    }

    //クリアパネルを表示させる
    void OnEnter()
    {
        //表示されたらムービー以外を消す

        //ムービースキップボタン

        //ムービーが終わったら操作説明を出す

        //操作説明の画面で少し経ったらボタンを表示させる
    }
}