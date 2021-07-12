using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Image hpStatus5;
    public Image hpStatus4;
    public Image hpStatus3;
    public Image hpStatus2;
    public Image hpStatus1;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        hpStatus1.enabled = false;
        hpStatus4.enabled = false;
        hpStatus3.enabled = false;
        hpStatus2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.hp == 5)
        //    hpStatus5.enabled = true;
        //if(player.hp ==)

        switch (player.hp)
        {
            case 5:
                hpStatus5.enabled = true;
                break;
            case 4:
                hpStatus5.enabled = false;
                hpStatus4.enabled = true;
                break;
        }
    }
}
