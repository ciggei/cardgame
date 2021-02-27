using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject EnemyArea;
    public GameObject AllyArea;
    public static int n_ally_cards = -2;
    public static int n_enemy_cards;
    public const int c_max_cards = 4;
    public static int n_dropzone_cards;

    List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        cards.Add(Card1);
        cards.Add(Card2);
    }

    public void onClick()
    {

        // Inizio Partita
        if (n_ally_cards == -2)
        {
            for (var i = 0; i < 5; i++)
            {
                GameObject playercard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
                playercard.transform.SetParent(AllyArea.transform, false);

                /*
                GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
                enemyCard.transform.SetParent(EnemyArea.transform, false);
                */

                n_ally_cards = i;
                n_enemy_cards = i;

            }
        }
        else
        {
            // pesca una sola carta
            if ( n_ally_cards < c_max_cards ) {
                for (var i = 0; i < 1; i++)
                {
                    GameObject playercard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
                    playercard.transform.SetParent(AllyArea.transform, false);

                    n_ally_cards = n_ally_cards + 1;
                }
            }
        }

        Debug.Log("Carte alleate : " + (n_ally_cards + 1));
    }
}
