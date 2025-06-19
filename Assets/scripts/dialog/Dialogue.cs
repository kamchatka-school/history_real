using System;
using UnityEngine;


[Serializable]
public class Answers
{
    public string text;
    public Dialogue nextDialogue;
}


[Serializable]
public class Phrase
{
    public string name;
    public string text;
    public Answers[] answers;
}


[CreateAssetMenu (menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{


    public Phrase[] phrases;
    public int curStep = 0;


    public void Initialize()
    {
        curStep = 0;
    }


    public Phrase NextPhrase()
    {
        Phrase curPhrase = phrases[curStep];
        if (curStep + 1 < phrases.Length)
        {
            curStep += 1;
            return curPhrase;
        }
        else
        {
            return null;
        }
    }


    public Phrase GetCurPhrase()
    {
        return phrases[curStep];
    }
}
