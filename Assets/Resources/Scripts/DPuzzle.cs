using UnityEngine;
using System.Collections;

public class DPuzzle : Default {
    public bool isSolved = false;
    public bool canCall = false;
    public string puzzle;
    public DragDrop[] Drag;
    public Animator fAnim;
    public Sprite[] aImg;
    public Animator iAnim;

    void startPuzzle()
    {
        canCall = true;
    }
    void outPuzzle() { }
	// Update is called once per frame
	void Update () 
    {
	    if(!isSolved && canCall)
        {
	    	
            switch(puzzle)
            {
                #region Joao
            case "joao_1":
                int e = 0;
                    for (int i = 0; i < Drag.Length;i++ )
                    {
                        if (Drag[i].matchAttached) e++;
                    }
                    if (e.Equals(Drag.Length))
                    {
                        Animator a = transform.FindChild("EnterPuzzle").GetComponent<Animator>();
                        a.SetInteger("tutorialType", 2);
                        a.enabled = false;
                        Destroy(transform.FindChild("Grandma").FindChild("Lightning").gameObject);
                        Destroy(transform.FindChild("Grandma").FindChild("Lightning1").gameObject);
                        Destroy(transform.FindChild("Grandma").FindChild("Lightning2").gameObject);
                        Destroy(transform.FindChild("EnterPuzzle").transform.FindChild("hand").gameObject);
                        iAnim.enabled = false;
                        fAnim.SetBool("isSolved", true);
                        isSolved = true;
                        FindObjectOfType<Player>().isWalking = true;
                        }
                break;


            case "joao_2"://drag All
                Animator g = transform.FindChild("EnterPuzzle").GetComponent<Animator>();
                       g.SetInteger("tutorialType", 2);
                    int n = 0;
                for (int i = 0; i < Drag.Length;i++)
                {
                    if (Drag[i].wasTouched) n++;
                }
                if(n.Equals(Drag.Length))
                {
                    int k = 0;
                    for (int i = 0; i < Drag.Length; i++)
                    {
                        Drag[i].canMatch = true;
                        if (Drag[i].matchAttached) k++;
                    }
                }
                else
                {
                    for (int i = 0; i < Drag.Length; i++)
                    {
                        Drag[i].canMatch = false;
                    }
                }
                int m=0;
                for (int i = 0; i < Drag.Length; i++)
                {
                    if (Drag[i].matchAttached) m++;
                }
                if (m.Equals(Drag.Length))
                {
                    FindObjectOfType<Player>().isWalking = true;
                    fAnim.SetBool("isSolved", true);
                    Animator a = transform.FindChild("EnterPuzzle").GetComponent<Animator>();
                    a.SetInteger("tutorialType", 3);
                    a.enabled = false;
                    Drag[0].match.GetComponent<SpriteRenderer>().sprite = aImg[0];
                    Destroy(transform.FindChild("EnterPuzzle").transform.FindChild("hand").gameObject);
                    isSolved = true;
                }
                    break;
            case "joao_3":
               Animator x = transform.FindChild("EnterPuzzle").GetComponent<Animator>();
                       x.SetInteger("tutorialType", 3);
                    if (FindObjectOfType<Player>().paperCount > 0)
                    {
                        FindObjectOfType<Player>().isWalking = true;
                        transform.FindChild("EnterPuzzle").GetComponent<Animator>().enabled = false;
                        Destroy(transform.FindChild("EnterPuzzle").transform.FindChild("hand").gameObject);
                        fAnim.SetBool("isSolved", true);
                        isSolved = true;
                    }

                        break;
			case "joao_4":
                        if (Drag[0].matchAttached)
                        {
                            isSolved = true;
                            fAnim.SetBool("isSolved", true);
                        }
				break;

            case "joao_5":
                int o = 0;
                for (int i = 0; i < Drag.Length;i++)
                {
                    if (Drag[i].matchAttached) o++;

                }
                if (o.Equals(Drag.Length))
                {
                    fAnim.SetBool("isSolved", true);
                    isSolved = true;
                }
                break;

            #endregion
            }

        }

	}
}
