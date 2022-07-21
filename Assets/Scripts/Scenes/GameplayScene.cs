using UnityEngine;

public class GameplayScene : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.instance)
            MusicManager.ChangeMusic(MusicManager.instance.gameplayMusic);
    }

}
