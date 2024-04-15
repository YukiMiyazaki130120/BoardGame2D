using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl_4 : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText, player3MoveText, player4MoveText;

    private static GameObject player1, player2, player3, player4;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player3StartWaypoint = 0;
    public static int player4StartWaypoint = 0;

    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");
        player3MoveText = GameObject.Find("Player3MoveText");
        player4MoveText = GameObject.Find("Player4MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        player1.GetComponent<FollowThePath_4>().moveAllowed = false;
        player2.GetComponent<FollowThePath_4>().moveAllowed = false;
        player3.GetComponent<FollowThePath_4>().moveAllowed = false;
        player4.GetComponent<FollowThePath_4>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        player3MoveText.gameObject.SetActive(false);
        player4MoveText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponent<FollowThePath_4>().waypointIndex > player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath_4>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath_4>().waypointIndex - 1;
        }
        if(player2.GetComponent<FollowThePath_4>().waypointIndex > player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath_4>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath_4>().waypointIndex - 1;
        }
        if(player3.GetComponent<FollowThePath_4>().waypointIndex > player3StartWaypoint + diceSideThrown)
        {
            player3.GetComponent<FollowThePath_4>().moveAllowed = false;
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(true);
            player3StartWaypoint = player3.GetComponent<FollowThePath_4>().waypointIndex - 1;
        }
        if(player4.GetComponent<FollowThePath_4>().waypointIndex > player4StartWaypoint + diceSideThrown)
        {
            player4.GetComponent<FollowThePath_4>().moveAllowed = false;
            player4MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player4StartWaypoint = player4.GetComponent<FollowThePath_4>().waypointIndex - 1;
        }
        if(player1.GetComponent<FollowThePath_4>().waypointIndex == player1.GetComponent<FollowThePath_4>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
            StartCoroutine(GameOver());
        }
        if(player2.GetComponent<FollowThePath_4>().waypointIndex == player2.GetComponent<FollowThePath_4>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
            StartCoroutine(GameOver());
        }
        if(player3.GetComponent<FollowThePath_4>().waypointIndex == player3.GetComponent<FollowThePath_4>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 3 Wins";
            gameOver = true;
            StartCoroutine(GameOver());
        }
        if(player4.GetComponent<FollowThePath_4>().waypointIndex == player4.GetComponent<FollowThePath_4>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player4MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 4 Wins";
            gameOver = true;
            StartCoroutine(GameOver());
        }


    }
    
    IEnumerator GameOver(){
        if(gameOver)
        {
            gameOver = false;
            player1StartWaypoint = 0;
            player2StartWaypoint = 0;
            player3StartWaypoint = 0;
            player4StartWaypoint = 0;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("Title");
        }
        yield break; 
    }

    public static void MovePlayer(int playerToMove)
    {
        switch(playerToMove) {
            case 0:
                player1.GetComponent<FollowThePath_4>().moveAllowed = true;
                break;
            case 1:
                player2.GetComponent<FollowThePath_4>().moveAllowed = true;
                break;
            case 2:
                player3.GetComponent<FollowThePath_4>().moveAllowed = true;
                break;
            case 3:
                player4.GetComponent<FollowThePath_4>().moveAllowed = true;
                break;
        }
    }
}
