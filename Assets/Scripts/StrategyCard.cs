using UnityEngine;

public class StrategyCard : MonoBehaviour
{
    Strategy strategy;
    Color color;
    SendMethod sendMethod;

    public StrategyCard(Strategy strategy, Color color)
    {
        getSendMethod(strategy);
        this.color = color;
        this.strategy = strategy;
    }

    public void getSendMethod(Strategy strategy)
    {
        switch (strategy)
        {
            case Strategy.TRAP:
                sendMethod = SendMethod.RELEASE;
                break;
            case Strategy.INTERCEPT:
            case Strategy.COUNTERACT:
            case Strategy.DELETE:
            case Strategy.TRANSFER:
                sendMethod = SendMethod.CONFIDENTIAL;
                break;
            default:
                sendMethod = SendMethod.SECRECY;
                break;
        }
    }

    public Strategy getStrategy()
    {
        return strategy;
    }

    public Color getColor()
    {
        return color;
    }
}

    
