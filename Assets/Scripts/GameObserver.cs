using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class GameObserver : MonoBehaviour
{
    private int turn = 0;
    private Player[] playerArray;
    private Agent[] dealedAgents;
    private Player _player;
    private List<Player> _cPUs;
    private AllDecks _allDecks;
    private StrategyCard sendedCard; // 黒沢先生実装時に再考の必要あり
    private Player currentPlayer;

    private bool sendedCardState = true; // true: 表  false: 裏
    private Player sendPlayer;

    private bool otamo = false;


    public GameObject chooseAgentPanel;
    public GameObject scrollcontent;
    public RectTransform prefab;
   
    /* エージェント選ぶ画面のボタンスプライト */
    private Button buttonImageAgentL;
    private Button buttonImageAgentR;

    /* 自分のエージェントと陣営のボタンスプライト */
    private Button buttonMyAgent;
    private Button buttonMySide;

    /* フェイズとターン表示（デバッグ用） */
    private Text textPhase;
    private Text textTurn;

    /* CPUのエージェント等のボタンスプライト */
    private Button[] buttonCPUAgents = new Button[8];

    /*  */
    public static GameObserver Instance;

    /* 現在のゲームフェイズ */
    private Phase currentPhase;

	// Use this for initialization
	void Start ()
	{
        Instance = this;
	    _allDecks = new AllDecks();
	    
	    /* UI関連の */
	    dealedAgents = showFirstAgents(_allDecks);
	    chooseAgentPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        // アプリケーション終了
	        Application.Quit();
	    }
	}

    private Agent[] showFirstAgents(AllDecks decks)
    {
        Agent[] agents = new Agent[2];
        for (int i = 0; i<2; i++)
        {
            agents[i] = decks.getAgentDeck().First.Value;
            decks.getAgentDeck().RemoveFirst();
        }
        
        buttonImageAgentL = GameObject.Find("ChooseAgent/AgentL").GetComponent<Button>();
        buttonImageAgentR = GameObject.Find("ChooseAgent/AgentR").GetComponent<Button>();
        buttonImageAgentL.image.sprite = Resources.Load<Sprite>("Agents/" + agents[0].getAgentName().ToString().ToLower());
        buttonImageAgentR.image.sprite = Resources.Load<Sprite>("Agents/" + agents[1].getAgentName().ToString().ToLower());
        Console.WriteLine("ABCDE");
        return agents;
    }

    /* エージェントを選んだあとの処理（ゲーム画面の準備） */
    public void chooseAgent(int number)
    {
        chooseAgentPanel.SetActive(false);
        setFirstDeal(_allDecks, dealedAgents[number]);
        prepareGameTable();
        //setCurrentPhase(Phase.START);
    }

    public void prepareGameTable()
    {
        /* 自分のエージェント・陣営・手札（未実装）の準備 */
        buttonMyAgent = GameObject.Find("GameTable/MyAgent").GetComponent<Button>();
        buttonMyAgent.image.sprite = Resources.Load<Sprite>("Agents/" + _player.getPlayerAgent().getAgentName().ToString().ToLower());
        buttonMySide = GameObject.Find("GameTable/MySide").GetComponent<Button>();
        buttonMySide.image.sprite = Resources.Load<Sprite>("Agents/" + _player.getPlayerSide().ToString().ToLower());

        /* CPUのエージェント・陣営・手札の準備 */
        for(int i=0; i<8; i++)
        {
            buttonCPUAgents[i] = GameObject.Find("GameTable/Player"+(i+1).ToString()+"/agent").GetComponent<Button>();
            buttonCPUAgents[i].image.sprite = Resources.Load<Sprite>("Agents/" + _cPUs[i].getPlayerAgent().getAgentName().ToString().ToLower());
        }
    }
    
    /* 初期状態の準備 */
    public void setFirstDeal(AllDecks decks, Agent selectedAgent){
        _player = firstDealforPlayer(decks, selectedAgent);
        _cPUs = firstDealforCPU(decks, 8);
        //playerList = _cPUs.Add();
        currentPlayer = setCurrentPlayer(turn);
        setHandsSprite(_player, 3);
        setCurrentPhase(Phase.START);
        
    }

    /* プレイヤーへの初期エージェント・手札の配布 */
    public Player firstDealforPlayer(AllDecks decks, Agent choosedAgent)
    {
        Side side;
        List<StrategyCard> hands = new List<StrategyCard>();

        side = decks.getSideDeck().First.Value;
        decks.getSideDeck().RemoveFirst();

        for(int i=0; i<3; i++) {
            hands.Add(decks.getStrategyDeck().First.Value);
            decks.getStrategyDeck().RemoveFirst();
        }

        return new Player(true, side, choosedAgent, hands);
    }

    /* CPUへの初期エージェント・手札の配布 */
    public List<Player> firstDealforCPU(AllDecks decks, int numCPUs)
    {
        List<Player> cPUs = new List<Player>();
        List<StrategyCard> hands;
        for (int i = 0; i < numCPUs; i++)
        {
            hands = new List<StrategyCard>();
            for (int j = 0; j < 3; j++)
            {
                hands.Add(decks.getStrategyDeck().First.Value);
                decks.getStrategyDeck().RemoveFirst();
            }
            cPUs.Add(new Player(false, decks.getSideDeck().First.Value, decks.getAgentDeck().First.Value, hands));
            decks.getSideDeck().RemoveFirst();
            decks.getAgentDeck().RemoveFirst();
        }
        return cPUs;
    }

    public void setHandsSprite(Player player, int add_num)
    {
        for (int i = player.getPlayerHands().Count - add_num; i < player.getPlayerHands().Count; i++) { 
            /* UI上での手札の追加 */
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.name = prefab.name + i.ToString();
            item.SetParent(scrollcontent.transform, false);
            var handImage = item.GetComponentInChildren<Button>();
            handImage.image.sprite = Resources.Load<Sprite>("Agents/" + _player.getPlayerHands()[i].getColor().ToString().ToLower()
            + _player.getPlayerHands()[i].getStrategy().ToString().ToLower());
        }
    }

    public  void setCurrentPhase(Phase phase)
    {
        currentPhase = phase;
        textPhase = GameObject.Find("GameTable/Phase").GetComponent<Text>();
        textPhase.text = currentPhase.ToString();
        switch (currentPhase)
        {
            case Phase.START:
                Debug.Log(Phase.START+_player.getPlayerHands().Count.ToString());
                setCurrentPhase(Phase.FILL);
                break;
            case Phase.FILL:
                Debug.Log(Phase.FILL+_player.getPlayerHands().Count.ToString());
                currentPlayer.drawCards(_allDecks);
                Debug.Log(_player.getPlayerHands().Count);
                setCurrentPhase(Phase.STRATEGY);
                break;
            case Phase.STRATEGY:
                break;
            case Phase.SEND:
                break;
            case Phase.FINISH:
                break;
        }
        
    }

    public Player setCurrentPlayer(int turn)
    {
        Player cplayer;

        switch (turn)
        {
            case 0:
                cplayer = _player;
                break;
           default:
                cplayer = _cPUs[turn - 1];
                break;
        }
        return cplayer;
    }

    public Phase getCurrentPhase()
    {
        return currentPhase;
    }

    public Player getPlayer()
    {
        return _player;
    }

    public void setSendState(Player sendPlayer, StrategyCard sendedCard)
    {
        this.sendedCard = sendedCard;
        this.sendPlayer = sendPlayer;
    }

    public void setSendIndex(int sendIndex, bool addOrRm)
    {
        if (addOrRm) { 
            _player.getSendIndexes().Add(sendIndex);
        }
        else
        {
            _player.getSendIndexes().Remove(sendIndex);
        }
    }
    
}



public enum Side
{
    KDR, FRS, MOF
}
public enum Color
{
    RED, BLUE, BLACK
}
public enum SendMethod
{
    SECRECY, CONFIDENTIAL, RELEASE
}

public enum Strategy
{
    LOCKON, DISTRIBUTE, INTERCEPT, DECODE, COUNTERACT, TRAP/*誤導*/, PROVEDRAW, PROVEDUMP, DELETE, TRANSFER

}

public enum Lockon
{
    LOCKON, LOST, NORMAL
}
public enum AgentAttribute
{
    SECRET, PUBLIC, NORMAL
}
public enum AbilityEffect
{
    RESIDENT, MOMENT
}
public enum Gender
{
    MALE, FEMALE, NONE
}
public enum Grade
{
    Y15, Y16, Y17, PROF, NONE
}

public enum Rarity
{
    NORMAL, RARE, SUPER, ULTRA
}

public enum Phase {
    START, FILL, STRATEGY, SEND, FINISH
}

public enum ListMode{
    HANDS, POSSESSION
}

public enum AgentName
{
     /* 既存エージェント */
    SPEAKER,
    TANK,
    OBLIQUESHADOW,
    TITANIUM,
    LARKLADY,
    SWANMAIDEN,
    HUNTRESS,
    BLACKHAND,
    NIGHTMARE,
    BARONBRUMAIRE,
    MARKJUNIOR,
    STATICELECTRICITY,
    VIPER,
    ANGEL,
    SAVAGEASSASSIN,
    DOUBLEKNIGHT,
    KWONKIKU,
    DARKFLOW,
    DIAMONDMAN,
    PERFUME,
    TOUGHGUN,
    REDBLADE,
    ALIAS,
    BACKFIRE,
    TRINITY,
    J,
    DETECTIVE,

    /* オリジナルエージェント */
    CHAINER,
    PSYCHOPATH,
    GOLDHEAD,
    NEUTRAL,
    GAMEMASTER,
    DUELIST,
    HANDSTANDER,
    SMALLSPACE,
    FILLER,
    MOMENTSLEEP,
    VITARITYRECORDER,
    CHAIRMAN,
    AMNESIA,
    TIPSY,
    PEPPER,
    JUGGLER,
    KUROSAWASENSEI,
    LIFEGAMER,
    SUNFLOWER,
    FISHCAKE,
    HOST,
    MORPHEUS,
    TRUMPETER,
    KEYBOARDER,
    JULIUS,
    FONTJUNKIE,
    SPRINCAR,
    BLACKPEPPER,
    SHELLKEAPER,
    IPHONE,
    SUNSHINE,
    PANDAPEPPER,
    TAKAYATSU,
    RAMEN,
}

public enum Labo
{
    NONE, KURO, HORY
}
