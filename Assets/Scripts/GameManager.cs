using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public enum GameState
{
    MainMenu, Playing, GameOver
}
public class GameManager : MonoBehaviour
{
    public Text currentHealth;
    private static GameManager _instance = null;
    private GameState _currentState;//TODO: right state machine
    private int _health = 5;

    [SerializeField]
    private GameObject[] objectsToSpawn;
    
    private UIManager UIManager;
    

    private IEnumerator _spawnCoroutine;

    public static GameManager Instance
    {
        get
        {
            return _instance;
            //Here must be right singleton 
        }
    }

    void Awake()
    {
        //lazy way singleton
        if (_instance == null)
            _instance = this;  
        else DestroyImmediate(gameObject);

        _currentState =GameState.MainMenu;
        UIManager = GetComponent<UIManager>();
        UIManager.ShowMainMenu();
        
    }

    public void ReduceHealth(int amount)
    {
        _health -=amount;
        currentHealth.text = "Health: " + _health;
        if (_health<=0) GameOver();
    }

    private void RefreshHealth()
    {
        currentHealth.text = "Health: " + _health;
        _health = 5;
    }
    public void StartGame()
    {
        RefreshHealth();
        _currentState=GameState.Playing;
        _spawnCoroutine=SpawnObjects();
        StartCoroutine(_spawnCoroutine);

        UIManager.ShowPlayingPanel();
    }
    
    public void GameOver()
    {
        _currentState=GameState.GameOver;
        StopCoroutine(_spawnCoroutine);

        UIManager.ShowGameOverPanel();
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            //Let the variable declaration optimization to the compiler
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            float spriteWidth = objectToSpawn.GetComponent<SpriteRenderer>().bounds.extents.x;
            Vector3 spawnMinPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 1)) +
                                  new Vector3(spriteWidth, 0, 0);
            Vector3 spawnMaxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1)) -
                                 new Vector3(spriteWidth, 0, 0);

            Instantiate(objectToSpawn, new Vector3(Random.Range(spawnMinPos.x, spawnMaxPos.x), spawnMaxPos.y, spawnMaxPos.z),
                Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }
    }
}
