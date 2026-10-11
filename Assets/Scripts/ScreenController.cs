using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private HudController hudController;
    [SerializeField] private InputActionReference pauseAction;
    [SerializeField] private int mainMenuSceneIndex = 0;

    [Header("Player & Cameras")]
    [SerializeField] private GameObject menuCamera;
    [SerializeField] private GameObject menuSpawner;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;

    [Header("UI Panels")]
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject hudPanel;

    [Header("End Screen Components")]
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    
    private static bool skipMainMenu = false;
    private bool isGameActive = false;
    private bool isPaused = false;

    private void Awake()
    {
        if(this.hudController == null)
        {
            Debug.LogError("ScreenController missing HudController reference!");
        }
        if(this.pauseAction == null)
        {
            Debug.LogError("ScreenController missing Pause Action reference!");
        }
        if(this.menuSpawner == null) 
        {
            Debug.LogError("ScreenController missing ConsumableSpawner reference!");
        }
    }

    private void OnEnable()
    {
        this.pauseAction.action.Enable();
        this.pauseAction.action.performed += this.TogglePause;
    }

    private void OnDisable()
    {
        this.pauseAction.action.Disable();
        this.pauseAction.action.performed -= this.TogglePause;
    }

    private void Start()
    {
        if (skipMainMenu == true)
        {
            skipMainMenu = false;
            this.StartGame();
            return;
        }

        this.ShowScreen(this.startScreen);
        
        this.SetGameState(false, 1.0f, CursorLockMode.None); 
        
        this.menuCamera.SetActive(true);
        this.playerCamera.SetActive(false);
        this.playerObject.SetActive(false);
        this.menuSpawner.SetActive(true);
        this.SetPlayerControls(false);
    }

    public void StartGame()
    {
        this.isGameActive = true;
        this.isPaused = false;

        this.menuSpawner.SetActive(false);
        
        ConsumableItem[] leftoverItems = Object.FindObjectsByType<ConsumableItem>();
        foreach(ConsumableItem item in leftoverItems)
        {
            Object.Destroy(item.gameObject);
        }
        
        this.menuCamera.SetActive(false);
        this.playerObject.SetActive(true); 
        this.playerCamera.SetActive(true);
        this.SetPlayerControls(true);

        this.hudController.StartTimer();
        this.ShowScreen(this.hudPanel);
        this.SetGameState(true, 1.0f, CursorLockMode.Locked);
    }

    public void ResumeGame()
    {
        if(this.isPaused == false)
        {
            return;
        }

        this.isPaused = false;
        this.ShowScreen(this.hudPanel);
        this.SetGameState(true, 1.0f, CursorLockMode.Locked);
        this.SetPlayerControls(true);
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        if(this.isGameActive == false)
        {
            return;
        }

        this.isPaused = !this.isPaused;
        
        if(this.isPaused == true)
        {
            this.ShowScreen(this.pauseScreen);
            this.SetGameState(false, 0.0f, CursorLockMode.None);
            this.SetPlayerControls(false);
        }
        else
        {
            this.ResumeGame();
        }
    }

    public void GameOver()
    {
        this.isGameActive = false;
        this.hudController.StopTimer();
        this.SetGameState(false, 0.0f, CursorLockMode.None);
        this.SetPlayerControls(false);
        
        this.SaveAndDisplayScores();
        this.ShowScreen(this.endScreen);
    }

    public void LoadMainMenu()
    {
        if(EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        this.PrepareForSceneLoad();
        SceneManager.LoadScene(this.mainMenuSceneIndex);
    }

    public void RestartGame()
    {
        skipMainMenu = true;
        this.PrepareForSceneLoad();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PrepareForSceneLoad()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    private void SaveAndDisplayScores()
    {
        float finalTime = this.hudController.GetTimeElapsed();
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0.0f);
        
        if(finalTime > bestTime)
        {
            bestTime = finalTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.Save();
        }

        this.finalTimeText.text = $"Final Time: {this.hudController.FormatTime(finalTime)}";
        this.bestTimeText.text = $"Best Time: {this.hudController.FormatTime(bestTime)}";
    }

    private void ShowScreen(GameObject screenToDisplay)
    {
        this.startScreen.SetActive(screenToDisplay == this.startScreen);
        this.pauseScreen.SetActive(screenToDisplay == this.pauseScreen);
        this.endScreen.SetActive(screenToDisplay == this.endScreen);
        this.hudPanel.SetActive(screenToDisplay == this.hudPanel);
    }

    private void SetGameState(bool active, float timeScale, CursorLockMode cursorMode)
    {
        Time.timeScale = timeScale;
        Cursor.lockState = cursorMode;
    }

    private void SetPlayerControls(bool enabled)
    {
        if(this.cameraController != null)
        {
            this.cameraController.enabled = enabled;
        }
        if(this.playerController != null)
        {
            this.playerController.enabled = enabled;
        }
    }
}