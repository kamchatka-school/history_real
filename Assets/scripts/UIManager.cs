using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button[] answerButton;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI speech;


    public Dialogue curDialogue;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (curDialogue != null)
            {
                curDialogue.NextPhrase();
                DialogueMoment();
            }
        }
    }


    void DialogueMoment()
    {
        Phrase curPhrase = curDialogue.GetCurPhrase();
        npcName.text = curPhrase.name;
        speech.text = curPhrase.text;


        for (int i = 0; i < curPhrase.answers.Length; i++)
        {
            int currentIndex = i;
            answerButton[i].gameObject.SetActive(true);


            answerButton[i].onClick.AddListener(() => SetNewDialogue(curPhrase.answers[currentIndex].nextDialogue));
            answerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = curPhrase.answers[i].text;
        }
        for (int i = curDialogue.GetCurPhrase().answers.Length; i < answerButton.Length; i++)
        {
            answerButton[i].onClick.RemoveAllListeners();
            answerButton[i].gameObject.SetActive(false);
        }
    }


    public void SetNewDialogue(Dialogue nextDialogue)
    {
        curDialogue = nextDialogue;
        curDialogue.Initialize();
        DialogueMoment();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DialogueOwner>(out DialogueOwner dialogueOwner))
        {
            curDialogue = dialogueOwner.dialogue;
            curDialogue.Initialize();
            DialogueMoment();
        }
    }
}
