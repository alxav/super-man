using UnityEngine;

public class GenerateBot : MonoBehaviour
{
    [SerializeField] private BotVariable bots;

    [Header("Area")] 
    [SerializeField] private float x; 
    [SerializeField] private float z;

    private Transform _transform;
    private Helper helper;

    private void Awake()
    {
        _transform = transform;
        helper = new Helper();
        Bot.KillBadBot += AddBadBot;
    }

    void Start()
    {
        GenerateBots(EnumBot.Good);
        GenerateBots(EnumBot.Bad);
    }


    private void AddBadBot(bool flag)
    {
        CreateBot(bots.Get(EnumBot.Bad));
    }
    
    private void CreateBot(BotData data)
    {
        var clone = Instantiate(data.Prefab, _transform);
        clone.transform.position = helper.GeneratePoint(x, z);

        clone.GetComponent<Bot>().Constructor(data.Type,data.Speed, x, z);

    }

    private void GenerateBots(EnumBot type)
    {
        var data = bots.Get(type);

        for (int i = 0; i < data.Count; i++)
        {
            CreateBot(data);
        }
    }


    private void OnDestroy()
    {
        Bot.KillBadBot -= AddBadBot;
    }
}
