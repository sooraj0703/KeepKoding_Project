using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager Instance;
    public Text coinNumber;
    public Text allCoinsCollected;

    public GameObject healthBar;
    public GameObject gameOverPanel;

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoinText(int coinCount)
    {
        Debug.Log("coinCount : "+ coinCount);
        coinNumber.text = "Coins : " + coinCount.ToString(); // Update the UI text with the coin count
        
        if(coinCount==5)      //checks whether all coins collected or not
        {
            allCoinsCollected.text = "All Coins Collected";
        }

    }
    public void updateHealth(int health)
    {
        if (healthBar.transform.childCount > 0)
        {
            Transform lastChild = healthBar.transform.GetChild(healthBar.transform.childCount - 1); // Get the last child
            Destroy(lastChild.gameObject); // Remove the last child component

            Debug.Log("health :"+health);

            if(health<1)       //checks health
            {
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
