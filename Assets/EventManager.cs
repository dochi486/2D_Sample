using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Image hpStatus5;
    Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.hp == 5)
            hpStatus5.enabled = true;
    }
}
