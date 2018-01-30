using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	bool playable;
	Side side;
	Agent agent;
	List<StrategyCard> possession = new List<StrategyCard>();
	List<StrategyCard> hands;
    List<int> sendIndexes;
	Lockon lockon;
	int draw_num;
    int send_num;
	ListMode mode;
	bool death;
	bool win;

	public Player(bool playable, Side side, Agent agent, List<StrategyCard> hands) {
		this.playable = playable;
		this.side = side;
		this.agent = agent;
		this.hands = new List<StrategyCard>(hands);
        this.sendIndexes = new List<int>();
        draw_num = 2;
        send_num = 1;
		mode = ListMode.HANDS;
		lockon = Lockon.NORMAL;
		death= false;
		win = false;
	}

    public Agent getPlayerAgent()
    {
        return agent;
    }

    public Side getPlayerSide()
    {
        return side;
    }

    public List<StrategyCard> getPlayerHands()
    {
        return hands;
    }

    public Lockon getPlayerLockoned()
    {
        return lockon;
    }

    public int getSendNum()
    {
        return send_num;
    }

    public List<int> getSendIndexes()
    {
        return sendIndexes;
    }

    /* プレイヤーの基本動作 */
    public void drawCards(AllDecks deck, int num = 2)
    {
        for (int i = 0; i < num; i++)
        {
            hands.Add(deck.getStrategyDeck().First.Value);
            deck.getStrategyDeck().RemoveFirst();
        }

        GameObserver.Instance.setHandsSprite(this, num);
    }

    public void dumpCards(AllDecks deck, List<StrategyCard> dumpCards)
    {
        for (int i = 0; i < dumpCards.Count; i++)
        {
            hands.Remove(dumpCards[i]);
        }
    }
    

    public void possessCards(List<StrategyCard> possessCards)
    {
        for (int i = 0; i < possessCards.Count; i++)
        {
            possession.Add(possessCards[i]);
        }
    }

    public void lockonPlayer()
    {
        lockon = Lockon.LOCKON;
    }

    public void lostPlayer()
    {
        lockon = Lockon.LOST;
    }
}
