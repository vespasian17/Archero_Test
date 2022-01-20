using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Text textAmountOfCoins;
    
    private int coins;

    public void AddCoins(int addCoins)
    {
        coins += addCoins;
    }

    private void Update()
    {
        textAmountOfCoins.text = coins.ToString();
    }
}
