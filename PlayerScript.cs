using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{

    //private Vector2 _direction = Vector2.right;
    private Vector2 _direction = Vector2.right;
    private List<Transform> _PlayerTrail = new List<Transform>();
    
    Collider2D wall;
    Vector2 lastWallEnd;
    Color wallColor;

    public float speed = 16;
    public float xPos;
    public float yPos;
    public GameObject Player;
    public GameObject playerTrailPreFab;
    public KeyCode UpKey;
    public KeyCode LeftKey;
    public KeyCode DownKey;
    public KeyCode RightKey;
    public int direction = 2;

    //  Vector3  lastPosition;

    // Start is called before the first frame update
    void Start()
    {

        GlobalVars.Player1IsAlive = true;
        GlobalVars.Player2IsAlive = true;
        GlobalVars.Player3IsAlive = true;
        GlobalVars.Player4IsAlive = true;


        //GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        //spawnWall();

        
        if (Player.name == "Player")
        {
            wallColor = GlobalVars.Player1Color;
        }
        else if (Player.name == "Player (1)")
        {
            wallColor = GlobalVars.Player2Color;

        }
        else if (Player.name == "Player (2)")
        {
            wallColor = GlobalVars.Player3Color;
        }
        else if (Player.name == "Player (3)")
        {
            wallColor = GlobalVars.Player4Color;

        }
        
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(UpKey) && (2 + direction != 10))
        {
           // if (!(GetComponent<Rigidbody2D>().velocity < 0.1))
            //{
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            spawnWall();
            direction = 2;
            //}

        }
        else if (Input.GetKeyDown(DownKey) && (8 + direction != 10))
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
            spawnWall();
            direction = 8;
        }
        else if (Input.GetKeyDown(RightKey) && (6 + direction != 10))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            spawnWall();
            direction = 6;
        }
        else if (Input.GetKeyDown(LeftKey) && (4 + direction != 10))
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
            spawnWall();
            direction = 4;
        }

        /*
        if (Input.GetKey(UpKey) )
        {
            _direction = Vector2.up;
            spawnWall();
        }
        else if (Input.GetKey(LeftKey))
        {
            _direction = Vector2.left;
            spawnWall();
        }
        else if (Input.GetKey(DownKey))
        {
            _direction = Vector2.down;
            spawnWall();
        }
        else if (Input.GetKey(RightKey))
        {
            _direction = Vector2.right;
            spawnWall();
        }
        */
        fitColliderBetween(wall, lastWallEnd, transform.position);

        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {
        /*
        //lastPosition = Player.transform.position;
        GlobalVars.keepTime += Time.deltaTime;
        //Debug.Log(GlobalVars.keepTime);
        this.transform.position = new Vector3(
    Mathf.Round(this.transform.position.x) + _direction.x,
    Mathf.Round(this.transform.position.y) + _direction.y,
    0.0f
    );
        //Vector3 offSet = Player.transform.position - lastPosition;
        //if (offSet.x != 0  || offSet.y != 0)
        //{
        //}
        */
        /*this.transform.position = new Vector3(
    Mathf.Round(this.transform.position.x) + _direction.x,
    Mathf.Round(this.transform.position.y) + _direction.y,
    0.0f
    );
        */
    }

    void fitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
    {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector2(dist + 1, 1);
        else
            co.transform.localScale = new Vector2(1, dist + 1);
    }
    private void ResetPlayer()
    {
        for (int i = _PlayerTrail.Count - 1; i > 1; i--)
        {
            //Destroys the object in that index
            Destroy(_PlayerTrail[i].gameObject);

        }
        // _segment.Clear(); clears the list and destroys all of the index's where there was no object
        _PlayerTrail.Clear();
        _PlayerTrail.Add(this.transform);

        //sets player back to 0
        this.transform.position =  new Vector3(xPos, yPos, 0);
    }

    private void spawnWall()
    {
        lastWallEnd = transform.position;

        GameObject playerTrail = Instantiate(playerTrailPreFab, transform.position, Quaternion.identity);
        playerTrail.GetComponent<Renderer>().material.color = wallColor;
        wall = playerTrail.GetComponent<Collider2D>();
        //playerTrail.position = _PlayerTrail[_PlayerTrail.Count].position;

        _PlayerTrail.Add(this.transform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other != wall)
        {
            Destroy(Player);
            //Debug.Log();
            if (Player.name == "Player")
            {
                GlobalVars.Player1IsAlive = false;
                
            }
            else if (Player.name == "Player (1)")
            {
                GlobalVars.Player2IsAlive = false;

            }
            else if (Player.name == "Player (2)")
            {
                GlobalVars.Player3IsAlive = false;
            }
            else if (Player.name == "Player (3)")
            {
                GlobalVars.Player4IsAlive = false;

            }
            if(GlobalVars.NumOfPlayers == 2)
            {
                if (!GlobalVars.Player1IsAlive || !GlobalVars.Player2IsAlive)
                {
                    SceneManager.LoadScene("GameOverScene");
                }
            }
            else if (GlobalVars.NumOfPlayers == 3)
            {
                if ( /*Player 3 is left alive*/(!GlobalVars.Player1IsAlive && !GlobalVars.Player2IsAlive && GlobalVars.Player3IsAlive) || /*Player 2 is left alive*/ (!GlobalVars.Player1IsAlive && GlobalVars.Player2IsAlive && !GlobalVars.Player3IsAlive) || /*Player 1  is left alive*/(GlobalVars.Player1IsAlive && !GlobalVars.Player2IsAlive && !GlobalVars.Player3IsAlive))
                {
                    SceneManager.LoadScene("GameOverScene");
                }
            }
            else if (GlobalVars.NumOfPlayers == 4)
            {
                if(/*player 4 is left alive*/ (!GlobalVars.Player1IsAlive && !GlobalVars.Player2IsAlive && !GlobalVars.Player3IsAlive && GlobalVars.Player4IsAlive) 
                    || /*player 3 is left alive*/ (!GlobalVars.Player1IsAlive && !GlobalVars.Player2IsAlive && GlobalVars.Player3IsAlive && !GlobalVars.Player4IsAlive) 
                    || /*player 2 is alive*/(!GlobalVars.Player1IsAlive && GlobalVars.Player2IsAlive && !GlobalVars.Player3IsAlive && !GlobalVars.Player4IsAlive) 
                    || /*player 1 is alive*/(GlobalVars.Player1IsAlive && !GlobalVars.Player2IsAlive && !GlobalVars.Player3IsAlive && !GlobalVars.Player4IsAlive))
                {
                    SceneManager.LoadScene("GameOverScene");
                }
            }

        }
    }
}
