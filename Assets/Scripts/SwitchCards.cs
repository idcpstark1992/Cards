using UnityEngine;

public class SwitchCards:MonoBehaviour
{

    public static SwitchCards Instance = null;
    public CardScript _PreviewDataPrefab;
    public delegate void Delegate_EnablePickPlayerCards(bool _bool);
    public bool Blocked;


    public Delegate_EnablePickPlayerCards Listener_PickPlayerCards { get; set; }
    public bool PressedTableCard { get; private set; }
    public CardData _TableCard { get; private set; }
    public CardScript  _playerCard { get; private set; }

    private GameObject ToDestroy;

    [SerializeField] private int CardSwichturns;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Blocked = true;
    }
    public void SetGameStart()
    {
        Blocked = false;
    }
    private  void SwitchCardData(CardScript _PreviusInfo =null,CardData _newInfo = null)
    {
        
        if (_PreviusInfo != null && _newInfo != null && !Blocked)
        {
            _PreviusInfo.gameObject.GetComponent<IAddCardData>().AddCardData(_newInfo);
            CardSwichturns--;
            if (CardSwichturns < 1)
            {
                UIController.Instance.CallCheckSession();
                PressedTableCard = true;
                Blocked = true;
            }
        }
            
    }
    public void SetTableCard(CardData _input, GameObject _TableCardObject)
    {
        _TableCard = _input;
        ToDestroy = _TableCardObject;
        ShowPreviewData();
    }
    public void SetPlayerCard(CardScript _InputCardScript)
    {
        _playerCard = _InputCardScript;
        SwitchCardData(_playerCard, _TableCard);
        HidePreviewData();
    }
    public void SetPresetTableStatus(bool _status)
    {
        PressedTableCard = _status;
    }
    private void ShowPreviewData()
    {
        _PreviewDataPrefab.gameObject.SetActive(true);
        _PreviewDataPrefab.GetComponent<IAddCardData>().AddCardData(_TableCard);
        Listener_PickPlayerCards?.Invoke(true);
    }
    private void HidePreviewData()
    {
        _PreviewDataPrefab.gameObject.SetActive(false);
        Listener_PickPlayerCards?.Invoke(false);
        ToDestroy.GetComponent<IShowCard>().ExitAnimation(Vector3.zero);
        PressedTableCard = false;
    }

    public void OnReset()
    {
        CardSwichturns = 3;
        ToDestroy = null;
        _TableCard = null;
        _playerCard = null;
        Blocked = true;
        _PreviewDataPrefab.gameObject.SetActive(false);
        Listener_PickPlayerCards?.Invoke(false);
    }
}
