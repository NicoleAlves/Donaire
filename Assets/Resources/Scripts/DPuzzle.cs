using UnityEngine;
using System.Collections;

public class DPuzzle : Default {
    public bool isSolved = false;
    public bool canCall = false;
    public static GameObject actualPlayer;
    public string puzzle;
    public int clickLimit;
    public Collider2D trigger;
    public Tap[] Tap;
    public Cleaner[] Cleaner;
    public DragDrop[] Drag;
    public Sprite[] alternativeImg;

    void startPuzzle()
    {
        canCall = true;
    }

	void outPuzzle()
	{
        if (!isSolved && Player.trys > 0)
        {
            Player.trys--;
            actualPlayer.transform.position = actualPlayer.GetComponent<Player>().lastCheckPoint.transform.position;
        }
        else if (Player.trys <= 0 && !isSolved)
        {
            Application.LoadLevel("GameOver");
        }
        
	}

	// Use this for initialization
	void Start () 
    {
        actualPlayer = GameObject.FindGameObjectWithTag("Joao");
	}
	
	// Update is called once per frame
	void Update () {
        
	if(!isSolved && canCall)
    {
		
        switch(puzzle)
        {
            #region Joao
            case "joao_1":
                int j = 0;
                for (int i = 0; i < Tap.Length;i++){
					if(Tap[i].clickTimes >= clickLimit && Tap[i].canClick) {
                        Tap[i].canClick = false;
                        Tap[i].gameObject.transform.localScale -= new Vector3(0.5f * Tap[i].gameObject.transform.localScale.x,
                            0.5f * Tap[i].gameObject.transform.localScale.y, 0);
						Tap[i].gameObject.GetComponent<SpriteRenderer>().sprite = alternativeImg[i];
					}
                    if (Tap[i].clickTimes >= clickLimit)
                    {
                        j++;
                    }
				}
                if (j == Tap.Length) isSolved = true;
                    break;

            case "joao_2"://drag All
                    int n = 0;
                for (int i = 0; i < Drag.Length;i++)
                {
                    if (Drag[i].isTouched) n++;
                }
                if(n.Equals(Drag.Length))
                {
                    
                    int k = 0;
                    for (int i = 0; i < Drag.Length; i++)
                    {
                        Drag[i].canMatch = true;
                        if (Drag[i].matchAttached) k++;
                    }
                    if (k.Equals(Drag.Length))
                    {
                        Drag[0].match.GetComponent<SpriteRenderer>().sprite = alternativeImg[0];
                        isSolved = true;
                    }

                }
                else
                {
                    for (int i = 0; i < Drag.Length; i++)
                    {
                        Drag[i].canMatch = false;
                    }
                }
                    break;
            case "joao_3":
                    int e = 0;
                    for (int i = 0; i < Drag.Length;i++ )
                    {
                        if (Drag[i].matchAttached) e++;
                    }
                    if (e.Equals(Drag.Length)) isSolved = true;

                        break;
			case "joao_4":
				if(Drag[0].matchAttached)isSolved = true;
				break;
			case "joao_5":
				if(!Cleaner[0].isVisible)isSolved = true;
				break;
            #endregion

            #region Maria 
			case "maria_1":
				int z = 0;
				for (int i = 0; i < Drag.Length; i++)
				{
					if (Drag[i].matchAttached) z++;
				}
				if (z.Equals(Drag.Length)) isSolved = true;
				break;

			case "maria_2":
				for (int i = 0; i < Tap.Length;i++){
					if(Tap[i].clickTimes >= clickLimit)
					{
                        if (Tap[i].gameObject.name.Equals("balãoBom"))
                        {
                            isSolved = true;
                        }
						//Adicionar codigo para mudar a imagem da moça.
					}
				}
				break;
			case "maria_3":
				n = 0;
				for (int i = 0; i < Drag.Length;i++)
				{
					if (Drag[i].isTouched) n++;
				}
				if(n.Equals(Drag.Length))
				{
					int k = 0;
					for (int i = 0; i < Drag.Length; i++)
					{
						Drag[i].canMatch = true;
						if (Drag[i].matchAttached) k++;
					}
					if (k.Equals(Drag.Length) && Tap[0].clickTimes >= clickLimit) isSolved = true;
					
				}
				else
				{
					for (int i = 0; i < Drag.Length; i++)
					{
						Drag[i].canMatch = false;
					}
				}
				break;
			case "maria_4":
				n = 0;
				for (int i = 0; i < Drag.Length;i++){
					if(Drag[i].matchAttached)
					{
						n++;
					}
				}
				if(n.Equals(Drag.Length))isSolved = true;
				break;
			case "maria_5":
				if(Drag[0].matchAttached)isSolved=true;
				break;
			case "maria_6":
				n = 0;
				for (int i = 0; i < Drag.Length;i++){
					if(Drag[i].matchAttached)
					{
						n++;
					}

				}
				if(n.Equals(Drag.Length))isSolved = true;
				break;
			case "maria_7":
				if(Drag[0].matchAttached)isSolved=true;
				break;

            #endregion

            #region Jose
			case "jose_1":
				n = 0;
				for (int i = 0; i < Drag.Length;i++){
					if(Drag[i].matchAttached)
					{
						n++;
					}
				}
				if(n.Equals(Drag.Length))isSolved = true;
				break;
			case "jose_2":
				if(Tap[0].clickTimes >= clickLimit)
				{
					isSolved = true;
				}
				break;
			case "jose_3":
                if (Tap[0].clickTimes >= clickLimit) isSolved = true;
				
				break;
			case "jose_4":
				n = 0;
				for (int i = 0; i < Drag.Length;i++){
					if(Drag[i].matchAttached)
					{
                        Drag[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
						n++;
					}
				}
				if(n.Equals(Drag.Length))isSolved = true;
				break;
			case "jose_5":
				n = 0;
				for (int i = 0; i < Drag.Length;i++){
					if(Drag[i].matchAttached)
					{
						n++;
					}
				}
				if(n.Equals(Drag.Length))isSolved = true;
				break;
			case "jose_6":
				if(Tap[0].clickTimes >= clickLimit)
				{
					isSolved = true;
				}
				break;
			case "jose_7":
				if(!Cleaner[0].isVisible)isSolved = true;
				break;
			case "jose_8":
                if (Tap[0].clickTimes >= clickLimit)
                {
                    isSolved = true;
                }
				break;
			case "jose_9":
                if (Tap[0].clickTimes >= clickLimit)
                {
                    isSolved = true;
                    Tap[0].gameObject.transform.position = new Vector3(6.58f, -1.35f, 0);
                }
				break;
            #endregion

        }

    }
	}
}
