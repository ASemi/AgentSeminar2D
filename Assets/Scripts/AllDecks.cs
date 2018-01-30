using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class AllDecks
{
    private LinkedList<StrategyCard> strategyDeck;
    private LinkedList<Agent> agentDeck;
    private LinkedList<Side> sideDeck;
    private LinkedList<StrategyCard> cemeteryDeck;

    public AllDecks()
    {
        prepareStrategyDeck();
        prepareAgentDeck();
        prepareSideDeck();
    }
    
    public void prepareStrategyDeck()
    {
        List<StrategyCard> tmpStrategyDeck = new List<StrategyCard>();
        strategyDeck = new LinkedList<StrategyCard>();
        
        foreach (Strategy strategy in Enum.GetValues(typeof(Strategy)))
        {
            //UnityEngine.Debug.Log(strategy.ToString());
            switch (strategy) {
                case Strategy.TRANSFER:    // 転送
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 3; i++) {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.TRAP:        // 誤導
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 3; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.COUNTERACT:  // 阻止
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 3; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.LOCKON:      // 捕捉
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 4; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.DISTRIBUTE:  // 分配
                    tmpStrategyDeck.Add(new StrategyCard(strategy, Color.RED));
                    tmpStrategyDeck.Add(new StrategyCard(strategy, Color.BLUE));
                    break;
                case Strategy.DELETE:      // 削除
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 2; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.DECODE:      // 解読
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 2; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.PROVEDRAW:       // 証明（２枚ドロー）
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 2; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.PROVEDUMP:       // 証明（１枚捨て）
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 2; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                case Strategy.INTERCEPT:   // 奪取
                    foreach (Color color in Enum.GetValues(typeof(Color))) {
                        for (int i = 0; i < 3; i++)
                        {
                            tmpStrategyDeck.Add(new StrategyCard(strategy, color));
                        }
                    }
                    break;
                default:
                    Console.Error.WriteLine("No such agent...");
                    break;
            }
            //UnityEngine.Debug.Log(Strategy.INTERCEPT);
            //UnityEngine.Debug.Log(strategy.ToString());
        }
        
        //Collections.shuffle(strategyDeck);
        tmpStrategyDeck = tmpStrategyDeck.OrderBy(i => Guid.NewGuid()).ToList();
        foreach (StrategyCard strategyCard in tmpStrategyDeck)
        {
            strategyDeck.AddLast(strategyCard);
            //UnityEngine.Debug.Log(strategyCard.getColor().ToString());
            UnityEngine.Debug.Log(strategyCard.getStrategy().ToString());
        }

    }

    public void prepareAgentDeck(){
        List<Agent> tmpAgentDeck = new List<Agent>();
        agentDeck = new LinkedList<Agent>();
        
        foreach(AgentName agentName in Enum.GetValues(typeof(AgentName))){
            tmpAgentDeck.Add(new Agent(agentName));
        }
        
        tmpAgentDeck = tmpAgentDeck.OrderBy(i => Guid.NewGuid()).ToList();
        foreach (Agent agent in tmpAgentDeck)
        {
            agentDeck.AddLast(agent);
        }
        
    }

    public void prepareSideDeck()
    {
        List<Side> tmpSideDeck = new List<Side>();
        sideDeck = new LinkedList<Side>();

        foreach (Side side in Enum.GetValues(typeof(Side)))
        {
            for (int i = 0; i < 3; i++)
            {
                tmpSideDeck.Add(side);
            }
        }

        //Collections.shuffle(sideDeck);
        tmpSideDeck = tmpSideDeck.OrderBy(i => Guid.NewGuid()).ToList();
        foreach (Side side in tmpSideDeck)
        {
            sideDeck.AddLast(side);
        }
    }

    public LinkedList<StrategyCard> getStrategyDeck()
    {
        return strategyDeck;
    }

    public LinkedList<Agent> getAgentDeck()
    {
        return agentDeck;
    }

    public LinkedList<Side> getSideDeck()
    {
        return sideDeck;
    }

    public LinkedList<StrategyCard> getCemeteryDeck()
    {
        return cemeteryDeck;
    }

    public void shuffleStrategyDeck(LinkedList<StrategyCard> deck)
    {
        Random rand = new Random(Environment.TickCount);

        for (LinkedListNode<StrategyCard> n = deck.First; n != null; n = n.Next)
        {
            StrategyCard v = n.Value;
            if (rand.Next(0, 2) == 1)
            {
                n.Value = deck.Last.Value;
                deck.Last.Value = v;
            }
            else
            {
                n.Value = deck.First.Value;
                deck.First.Value = v;
            }
        }
    }
}