using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnvState {Left, Right};

public class EnvironmentState : MonoBehaviour
{
    private EnvState env_state;
    
    public static bool play_music = true;
    public static int curr_level = 2;
    // Start is called before the first frame update
    void Start()
    {
        env_state = EnvState.Left;
    }

    public static void incrementCurrLevel() {
        curr_level += 1;
    }

    public static void ToggleMusic() {
        play_music = !play_music;
    }

    public void SetState(EnvState state) {
        env_state = state;
    }

    public EnvState GetState() {
        return env_state;
    }
}
