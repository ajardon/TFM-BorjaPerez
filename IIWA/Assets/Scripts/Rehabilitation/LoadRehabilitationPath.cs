using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRehabilitationPath : MonoBehaviour
{

    public GameObject vertical1, vertical2, vertical3, vertical1M, vertical2M, vertical3M, horizontal1, horizontal2, horizontal3, cameraV1, cameraV2, cameraH;
    public GameObject ballV1S, ballV2S, ballHS, ballV1M, ballV2M, ballHM, ballV1B, ballV2B, ballHB, coinsR, coinsL, coinsH, score;

    public GameObject pathLimit11N, pathLimit12N, pathLimit13N, pathLimit11M, pathLimit12M, pathLimit13M, pathLimit11F, pathLimit12F, pathLimit13F; 
    public GameObject pathLimit21N, pathLimit22N, pathLimit23N, pathLimit21M, pathLimit22M, pathLimit23M, pathLimit21F, pathLimit22F, pathLimit23F; 
    public GameObject pathLimitH1N, pathLimitH2N, pathLimitH3N, pathLimitH1M, pathLimitH2M, pathLimitH3M, pathLimitH1F, pathLimitH2F, pathLimitH3F; 


    private int width, paths, position, mode, ball = 0, pathLimit;

    void Start()
    {
        vertical1.gameObject.SetActive(false); 
        vertical2.gameObject.SetActive(false); 
        vertical3.gameObject.SetActive(false); 
        vertical1M.gameObject.SetActive(false); 
        vertical2M.gameObject.SetActive(false); 
        vertical3M.gameObject.SetActive(false); 
        horizontal1.gameObject.SetActive(false); 
        horizontal2.gameObject.SetActive(false); 
        horizontal3.gameObject.SetActive(false);
        cameraV1.gameObject.SetActive(false);
        cameraV2.gameObject.SetActive(false);
        cameraH.gameObject.SetActive(false);
        ballV1S.gameObject.SetActive(false);
        ballV2S.gameObject.SetActive(false);
        ballHS.gameObject.SetActive(false);
        ballV1M.gameObject.SetActive(false);
        ballV2M.gameObject.SetActive(false);
        ballHM.gameObject.SetActive(false);
        ballV1B.gameObject.SetActive(false);
        ballV2B.gameObject.SetActive(false);
        ballHB.gameObject.SetActive(false);
        coinsL.gameObject.SetActive(false);
        coinsR.gameObject.SetActive(false);
        coinsH.gameObject.SetActive(false);
        pathLimit11N.gameObject.SetActive(false);
        pathLimit12N.gameObject.SetActive(false);
        pathLimit13N.gameObject.SetActive(false);
        pathLimit11M.gameObject.SetActive(false);
        pathLimit12M.gameObject.SetActive(false);
        pathLimit13M.gameObject.SetActive(false);
        pathLimit11F.gameObject.SetActive(false);
        pathLimit12F.gameObject.SetActive(false);
        pathLimit13F.gameObject.SetActive(false);
        pathLimit21N.gameObject.SetActive(false);
        pathLimit22N.gameObject.SetActive(false);
        pathLimit23N.gameObject.SetActive(false);
        pathLimit21M.gameObject.SetActive(false);
        pathLimit22M.gameObject.SetActive(false);
        pathLimit23M.gameObject.SetActive(false);
        pathLimit21F.gameObject.SetActive(false);
        pathLimit22F.gameObject.SetActive(false);
        pathLimit23F.gameObject.SetActive(false);
        pathLimitH1N.gameObject.SetActive(false);
        pathLimitH2N.gameObject.SetActive(false);
        pathLimitH3N.gameObject.SetActive(false);
        pathLimitH1M.gameObject.SetActive(false);
        pathLimitH2M.gameObject.SetActive(false);
        pathLimitH3M.gameObject.SetActive(false);
        pathLimitH1F.gameObject.SetActive(false);
        pathLimitH2F.gameObject.SetActive(false);
        pathLimitH3F.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
        LoadRehabilitation();
    }

    public void LoadRehabilitation()
    {
        position = PlayerPrefs.GetInt("Position");
        paths = PlayerPrefs.GetInt("Paths");
        width = PlayerPrefs.GetInt("Widht");
        mode = PlayerPrefs.GetInt("GameModeRe");
        ball = PlayerPrefs.GetInt("Ball");
        pathLimit = PlayerPrefs.GetInt("PathLimit");

        if (position == 1) //VERTICAL
        {
            if (paths == 1) //1 PATH
            {
                cameraV1.gameObject.SetActive(true);
                cameraH.gameObject.SetActive(false);
                cameraV2.gameObject.SetActive(false);
              
                //TAMAÑO DE LA PELOTA
                if (ball == 0)
                {
                    ballV1M.gameObject.SetActive(true);
                }
                if (ball == 1)
                {
                    ballV1S.gameObject.SetActive(true);
                }
                if (ball == 2)
                {
                    ballV1B.gameObject.SetActive(true);
                }


                //ANCHURA DEL PATH
                if (width == 1) //GRANDE
                {
                    vertical1.gameObject.SetActive(true);
                    if (pathLimit == 0)
                    {
                        pathLimit11M.gameObject.SetActive(true);
                    }
                    if (pathLimit == 1)
                    {
                        pathLimit11N.gameObject.SetActive(true);
                    }
                    if (pathLimit == 2)
                    {
                        pathLimit11F.gameObject.SetActive(true);
                    }
                }
                if (width == 2) //MEDIANO
                {
                    vertical2.gameObject.SetActive(true);
                    if (pathLimit == 0)
                    {
                        pathLimit12M.gameObject.SetActive(true);
                    }
                    if (pathLimit == 1)
                    {
                        pathLimit12N.gameObject.SetActive(true);
                    }
                    if (pathLimit == 2)
                    {
                        pathLimit12F.gameObject.SetActive(true);
                        Debug.Log("Path limit dentro");
                    }
                }
                if (width == 3) //PEQUEÑO
                {
                    vertical3.gameObject.SetActive(true); 
                    if (pathLimit == 0)
                    {
                        pathLimit13M.gameObject.SetActive(true);
                    }
                    if (pathLimit == 1)
                    {
                        pathLimit13N.gameObject.SetActive(true);
                    }
                    if (pathLimit == 2)
                    {
                        pathLimit13F.gameObject.SetActive(true);
                    }
                }

                if (mode == 1) //BASIC
                {
                    coinsL.gameObject.SetActive(false);
                    coinsR.gameObject.SetActive(false);
                    coinsH.gameObject.SetActive(false);
                    score.gameObject.SetActive(false);
                }
                if (mode == 2) //OBSTACLES
                {
                    coinsL.gameObject.SetActive(false);
                    coinsR.gameObject.SetActive(true);
                    coinsH.gameObject.SetActive(false);
                    score.gameObject.SetActive(true);
                }
            }
            if (paths == 2) //2 PATHS
            {
                cameraV2.gameObject.SetActive(true);
                cameraH.gameObject.SetActive(false);
                cameraV1.gameObject.SetActive(false);
                
                if (ball == 0)
                {
                    ballV1M.gameObject.SetActive(true);
                    ballV2M.gameObject.SetActive(true);
                }
                if (ball == 1)
                {
                    ballV1S.gameObject.SetActive(true);
                    ballV2S.gameObject.SetActive(true);
                }
                if (ball == 2)
                {
                    ballV1B.gameObject.SetActive(true);
                    ballV2B.gameObject.SetActive(true);
                }

                if (width == 1) //GRANDE
                {
                    vertical1.gameObject.SetActive(true);
                    vertical1M.gameObject.SetActive(true);

                    if (pathLimit == 0)
                    {
                        pathLimit11M.gameObject.SetActive(true);
                        pathLimit21M.gameObject.SetActive(true);
                        Debug.Log("Limits = 11M, 21M");
                    }
                    if (pathLimit == 1)
                    {
                        pathLimit11N.gameObject.SetActive(true);
                        pathLimit21N.gameObject.SetActive(true);
                        Debug.Log("Limits = 11n, 21n");

                    }
                    if (pathLimit == 2)
                    {
                        pathLimit11F.gameObject.SetActive(true);
                        pathLimit21F.gameObject.SetActive(true);
                        Debug.Log("Limits = 11f, 21f");

                    }
                }
                if (width == 2) //MEDIANO
                {
                    vertical2.gameObject.SetActive(true);
                    vertical2M.gameObject.SetActive(true);
                    if (pathLimit == 0)
                    {
                        pathLimit12M.gameObject.SetActive(true);
                        pathLimit22M.gameObject.SetActive(true);
                    }
                    if (pathLimit == 1)
                    {
                        pathLimit12N.gameObject.SetActive(true);
                        pathLimit22N.gameObject.SetActive(true);
                    }
                    if (pathLimit == 2)
                    {
                        pathLimit12F.gameObject.SetActive(true);
                        pathLimit22F.gameObject.SetActive(true);
                    }
                }
                if (width == 3)  //PEQUEÑO
                {
                    vertical3.gameObject.SetActive(true);
                    vertical3M.gameObject.SetActive(true);
                    if (pathLimit == 0)
                    {
                        pathLimit13M.gameObject.SetActive(true);
                        pathLimit23M.gameObject.SetActive(true);
                    }
                    if (pathLimit == 1)
                    {
                        pathLimit13N.gameObject.SetActive(true);
                        pathLimit23N.gameObject.SetActive(true);
                    }
                    if (pathLimit == 2)
                    {
                        pathLimit13F.gameObject.SetActive(true);
                        pathLimit23F.gameObject.SetActive(true);
                    }
                }

                if (mode == 1) //BASIC
                {
                    coinsL.gameObject.SetActive(false);
                    coinsR.gameObject.SetActive(false);
                    coinsH.gameObject.SetActive(false);
                    score.gameObject.SetActive(false);
                }
                if (mode == 2) //OBSTACLES
                {
                    coinsL.gameObject.SetActive(true);
                    coinsR.gameObject.SetActive(true);
                    coinsH.gameObject.SetActive(false);
                    score.gameObject.SetActive(true);
                }
            }
        }

        if (position == 2) //HORIZONTAL
        {
            cameraH.gameObject.SetActive(true);
            cameraV1.gameObject.SetActive(false);
            cameraV2.gameObject.SetActive(false);
            
            if (ball == 0)
            {
                ballHM.gameObject.SetActive(true);
            }
            if (ball == 1)
            {
                ballHS.gameObject.SetActive(true);
            }
            if (ball == 2)
            {
                ballHB.gameObject.SetActive(true);
            }

            if (width == 1) //GRANDE
            {
                horizontal1.gameObject.SetActive(true);

                if (pathLimit == 0)
                {
                    pathLimitH1M.gameObject.SetActive(true);
                }
                if (pathLimit == 1)
                {
                    pathLimitH1N.gameObject.SetActive(true);
                }
                if (pathLimit == 2)
                {
                    pathLimitH1F.gameObject.SetActive(true);
                }
            }
            if (width == 2) //MEDIANO
            {
                horizontal2.gameObject.SetActive(true);
                if (pathLimit == 0)
                {
                    pathLimitH2M.gameObject.SetActive(true);
                }
                if (pathLimit == 1)
                {
                    pathLimitH2N.gameObject.SetActive(true);
                }
                if (pathLimit == 2)
                {
                    pathLimitH2F.gameObject.SetActive(true);
                }
            }
            if (width == 3) //PEQUEÑO
            {
                horizontal3.gameObject.SetActive(true);
                if (pathLimit == 0)
                {
                    pathLimitH3M.gameObject.SetActive(true);
                }
                if (pathLimit == 1)
                {
                    pathLimitH3N.gameObject.SetActive(true);
                }
                if (pathLimit == 2)
                {
                    pathLimitH3F.gameObject.SetActive(true);
                }
            }

            if (mode == 1) //BASIC
            {
                coinsL.gameObject.SetActive(false);
                coinsR.gameObject.SetActive(false);
                coinsH.gameObject.SetActive(false);
                score.gameObject.SetActive(false);
            }
            if (mode == 2) //OBSTACLES
            {
                coinsL.gameObject.SetActive(false);
                coinsR.gameObject.SetActive(false);
                coinsH.gameObject.SetActive(true);
                score.gameObject.SetActive(true);
            }
        }
    }
}
