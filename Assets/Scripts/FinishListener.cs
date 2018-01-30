using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishListener : MonoBehaviour
{

    private Button finishButton;
    private Phase phase;
    private Player player;

    

    // Use this for initialization
    void Start()
    {
        finishButton = GetComponent<Button>();
    }

    public void onFinishListener()
    {
        phase = GameObserver.Instance.getCurrentPhase();
        switch (phase)
        {
            case Phase.STRATEGY:
                GameObserver.Instance.setCurrentPhase(Phase.SEND);
                finishButton.GetComponentInChildren<Text>().text = "決定";
                break;
            case Phase.SEND:
                player = GameObserver.Instance.getPlayer();
                //GameObserver.Instance.setSendState(player, player.getPlayerHands()[handIndex]);
                //player.getPlayerHands().Remove(player.getPlayerHands()[handIndex]);
                break;
            default:
                break;
        }
    }
}
