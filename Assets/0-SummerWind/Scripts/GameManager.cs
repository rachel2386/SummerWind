
using Opsive.UltimateCharacterController.Character;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool PlayerSitDown = false;
    [HideInInspector]public bool GameEnded = false;
    private bool continuedGame = false;
    private PlayMakerFSM TimelineFSM;

    public bool EnableIntroSequence = false;
    public bool EnableEndSequence = false;

    private GameObject m_Character;
    private UltimateCharacterLocomotion characterController;
    // Start is called before the first frame update
    void Start()
    {
        m_Character = GameObject.FindGameObjectWithTag("Player");
        characterController = m_Character.GetComponent<UltimateCharacterLocomotion>();
        TimelineFSM = PlayMakerFSM.FindFsmOnGameObject(GameObject.Find("TimeLine"), "KiteToPlayerClipControl");
        
    }

    // Update is called once per frame
    void Update()
    {
        //start game with player sit down
//        if (!PlayerSitDown)
//        {
//           var sitAbility = characterController.GetAbility<SitDown>();
//           characterController.TryStartAbility(sitAbility);
//           PlayerSitDown = true;
//        }

        if (GameEnded)
        {
            //restart game
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
            //continue exploration
            if (!continuedGame)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("spacePressed");
                    TimelineFSM.SetState("ContinueExploration");
                    continuedGame = true;
                }
                
            }

            
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            SceneManager.LoadScene(0);
            Debug.Log("Reset Game");
        }
    }

    public void EndGame()
    {
        GameEnded = true;
    }
}
