using UnityEngine;
public class npc
{
    public bool doneTask;
    public bool isActive;
    public string name;
    public string[] preTaskDialogue,postTaskDialogue;
    public string minigameScene;
    public npc(string name, string minigameScene)
    {
        this.name = name;
        this.minigameScene = minigameScene;
    }
    public npc(string name, string minigameScene, string[] preTaskDialogue)
    {
        this.name = name;
        this.minigameScene = minigameScene;
        this.preTaskDialogue = preTaskDialogue;
    }
    public npc(string name, string minigameScene, string[] preTaskDialogue, string[] postTaskDialogue)
    {
        this.name = name;
        this.minigameScene = minigameScene;
        this.preTaskDialogue = preTaskDialogue;
        this.postTaskDialogue = postTaskDialogue;
    }
}
