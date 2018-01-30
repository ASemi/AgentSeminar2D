using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandsListener : MonoBehaviour {

    private Button handButton;
    private Phase phase;
    private Player player;

    private float _Step = 0.008f;
    private bool flag = false;


    // Use this for initialization
    void Start () {

        handButton = GetComponent<Button>();
	}

    void Update()
    {
        player = GameObserver.Instance.getPlayer();
        if (flag) {
            // 現在のAlpha値を取得
            float toColor = handButton.GetComponent<Image>().color.a;
            // Alphaが0 または 1になったら増減値を反転
            if (toColor < 0.6 || toColor > 1)
            {
                _Step = _Step * -1;
            }
            // Alpha値を増減させてセット
            handButton.GetComponent<Image>().color = new UnityEngine.Color(255, 255, 255, toColor + _Step);
        }
        else
        {
            handButton.GetComponent<Image>().color = new UnityEngine.Color(255, 255, 255, 1);
        }
    }

    public void onClickHands()
    {
        int handIndex;

        phase = GameObserver.Instance.getCurrentPhase();
        player = GameObserver.Instance.getPlayer();
        handIndex = int.Parse(handButton.name.Substring(4)); // オブジェクト名から何番目の手札を送信するかを取得

        switch (phase)
        {
            case Phase.STRATEGY:

                break;
            case Phase.SEND:
                if (player.getSendIndexes().Count < player.getSendNum())
                {
                    GameObserver.Instance.setSendIndex(handIndex, true);
                    flag = true;
                }else if (flag){
                    flag = false;
                    GameObserver.Instance.setSendIndex(handIndex, false);
                }
                break;
            default:
                break;
        }
    }
}
