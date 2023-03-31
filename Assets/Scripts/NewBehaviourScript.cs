using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] crosses = new GameObject[9];
    public GameObject[] zeros = new GameObject[9];
    public GameObject winScreen;
    public GameObject gamePlace;
    public TextMeshProUGUI textObject;
    private int[] _fields = new int[9];
    private int _field;
    private bool _isPlayerTurn;
    private bool _isCrossPlayer;
    int steps;
    void Start()
    {
        steps= 0;
        _isCrossPlayer= true;
        _isPlayerTurn= true;

    }
    public void PlayerMove(int position)
    {
        if (_isPlayerTurn && _fields[position]==0) 
        {
            if (_isCrossPlayer)
            {
                crosses[position].SetActive(true);
                _fields[position] = 1;
            }
            else
            {
                zeros[position].SetActive(true);
                _fields[position] = 2;
            }
            steps++;
            _isPlayerTurn = false;
        }
    }
    void Update()
    {
        if (steps > 8)
        {
            ChangeText("Ничья");
            winScreen.SetActive(true);
            gamePlace.SetActive(false);

        }
        if (Check() != 0)
        {
            if (Check() == 1)
            {
                ChangeText("Крестики победили");
                winScreen.SetActive(true);
                gamePlace.SetActive(false);
            }
            else
            {
                ChangeText("Нолики победили");
                winScreen.SetActive(true);
                gamePlace.SetActive(false);

            }
        }else if(!_isPlayerTurn)
        {
            do
            {
                _field = Random.Range(0, 9);
            } while (_fields[_field] != 0);
            if(_isCrossPlayer)
            {
                zeros[_field].SetActive(true);
                _fields[_field] = 2;
            }
            else
            {
                crosses[_field].SetActive(true);
                _fields[_field] = 1;
            }
            _isPlayerTurn= true;
            steps++;

        }
    }
    int Check()
    {
        if (_fields[0] == _fields[1] && _fields[1] == _fields[2])
        {
            return _fields[0];
        }
        if (_fields[3] == _fields[4] && _fields[3] == _fields[5])
        {
            return _fields[3];
        }
        if (_fields[6] == _fields[7] && _fields[6] == _fields[8])
        {
            return _fields[6];
        }
        if (_fields[0] == _fields[3] && _fields[0] == _fields[6])
        {
            return _fields[0];
        }
        if (_fields[1] == _fields[4] && _fields[1] == _fields[7])
        {
            return _fields[1];
        }
        if (_fields[2] == _fields[5] && _fields[2] == _fields[8])
        {
            return _fields[2];
        }
        if (_fields[0] == _fields[4] && _fields[0] == _fields[8])
        {
            return _fields[0];
        }
        if (_fields[2] == _fields[4] && _fields[2] == _fields[6])
        {
            return _fields[2];
        }
        return 0;

    }
    void ChangeText(string text)
    {
        textObject.text = text;
    }
    public void PrepareField()
    {
        steps = 0;
        _isCrossPlayer = true;
        _isPlayerTurn = true;
        foreach (var cross in crosses)
        {
            cross.SetActive(false);
        }
        foreach (var zero in zeros)
        {
            zero.SetActive(false);
        }
        for (int i = 0; i < 9; i++)
        {
            _fields[i] = 0;
        }
        steps = 0;
        _isCrossPlayer = true;
        _isPlayerTurn = true;
    }
}
