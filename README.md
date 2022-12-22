# Magnum-Foundation-experimental

# Shakespere (Assets/Shakespere/)
This is the dialogue system I made which uses unity timeline.
### playable_dialogue
This is what controls the text that is put on in the speech bubble. The time interval between each word is calculated by this bit of code (represented by delta).
```
float delta = (float)(playable.GetDuration() / entireSentence.Length);
```

Probably for testing purposes, the sentence is re-written again - to prevent repeated words from popping up.
```
if (dialogueText.Length > 1)
        {
            int dialogueLeng = 0;
            foreach (var a in dialogueText)
            {
                dialogueLeng += a.dialogue.Length + 1;
                if (counter == dialogueLeng)
                    if (a.wait > 0)
                        stoppingPoint = new Tuple<int, float>(dialogueLeng, a.wait);
            }
        }
        string dialogue = "";

        for (int i = 0; i < entireSentence.Length; i++)
        {
            if ((i * delta) <= playable.GetTime())
            {
                dialogue += entireSentence[i];
            }
        }
        m_textBubble.text.text = dialogue;
        
```
