using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText, _livesText, _yourScore;
    [SerializeField] private GameObject _GameOver, _spawnerObject;
    [SerializeField] private GameObject _panelGameOver;
    private ControllerScript _playerScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.Find("Player").GetComponent<ControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();
        GameOver();
    }

    void UIUpdate()
    {
        _yourScore.text = "Your Score: " + _playerScript._score;
        _scoreText.text = "Score: " + _playerScript._score;
        _livesText.text = "Lives: " + _playerScript._lives;
    }

    void GameOver()
    {
        if (_playerScript._lives == 0)
        {
            _panelGameOver.SetActive(true);
            _playerScript.enabled = false;
            _spawnerObject.SetActive(false);
            LeanTween.moveY(_GameOver.GetComponent<RectTransform>(), 0f, 0.5f);
        }
    }

    public void PlayAgain()
    {
        _panelGameOver.SetActive(false);
        LeanTween.moveY(_GameOver.GetComponent<RectTransform>(), -950f, 0.5f);
        SceneManager.LoadScene("Main");
    }
    public void Exit()
    {
        _panelGameOver.SetActive(false);
        LeanTween.moveY(_GameOver.GetComponent<RectTransform>(), -950f, 0.5f);
        Application.Quit();
    }
}
