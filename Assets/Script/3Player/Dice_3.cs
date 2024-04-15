using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_3 : MonoBehaviour
{
    public Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 0;
    private bool coroutineAllowed = true;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        // diceSides = Resources.LoadAll<Sprite>("Assets/Image/DiceSides/");
        rend.sprite = diceSides[5];
        
    }

    private void OnMouseDown()
    {
        if(!GameControl_3.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for(int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0,6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl_3.diceSideThrown = randomDiceSide + 1;
        if(whosTurn == 0)
        {
            GameControl_3.MovePlayer(0);
        }else if(whosTurn == 1)
        {
            GameControl_3.MovePlayer(1);
        }else if(whosTurn == 2)
        {
            GameControl_3.MovePlayer(2);
        }
        whosTurn += 1;
        whosTurn %= 3;
        coroutineAllowed = true;
    }
}
