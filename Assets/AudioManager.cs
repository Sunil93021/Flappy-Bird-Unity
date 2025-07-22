using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip scoreSound;
    private static AudioManager instance;
    private void Awake()
    {
        ManageSingleton();
    }
    private void ManageSingleton()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
    public static AudioManager GetInstance()
    {
        return instance;
    }
    public void PlayScoreSound()
    {
        AudioSource.PlayClipAtPoint(scoreSound,Camera.main.transform.position,1f);
    }
}
