using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float CAM_ORTHO_SIZE = 20;
    private const float PIPE_WiDTH = 10.4f;
    private const float PIPE_HEAD_HEIGHT = 3.75f;
    private const float BIRD_X_POS = 0f;
    
    public static Level instance {get; private set;}
    
    
    private enum mode{UP,DOWN};
    private enum Difficulty{EASY, MEDIUM, HARD, IMPOSSIBLE}
    private enum State{WAITING, PLAYING, DEAD}
    private State state;
    private List<Pipe> pipeList;
    
    private float pipeSpawnTimer;
    private float pipeSpawnTimerMax;
    private float gapSize;
    private int score = 0;
    
    private int pipesSpawned = 0;
    void Awake()
    {
        instance = this;
        pipeList = new List<Pipe>();
        SetDifficulty(Difficulty.EASY);
        state = State.WAITING;
    }

    private void Start(){
        
        Bird.instance.OnDied += Level_OnDied;
        Bird.instance.OnStart += Level_OnStart;    
    }

    private void Level_OnDied(object sender, System.EventArgs e){
        state = State.DEAD;
    }
    private void Level_OnStart(object sender, System.EventArgs e){
        state = State.PLAYING;
    }
    void Update()
    {
        if (state == State.PLAYING){
            gapSize = UnityEngine.Random.Range(20, 15);
            HandlePipeMovement();
            HandlePipeSpawning();
        }
    }

    private void HandlePipeSpawning(){
        pipeSpawnTimer -= Time.deltaTime;
        if (pipeSpawnTimer < 0)
        {
            pipeSpawnTimer += pipeSpawnTimerMax;
            float heightEdgeLimit = 10f;
            float minHeight = gapSize * .5f + heightEdgeLimit;
            
            float totalHeight = CAM_ORTHO_SIZE * 2f;
            float maxHeight = totalHeight - gapSize * .5f - heightEdgeLimit;

            float height = UnityEngine.Random.Range(minHeight, maxHeight);
            CreateGapPipe(height,gapSize,GameAssets.instance.PIPE_SPAWN_X_POSITION);
            pipesSpawned++;
            SetDifficulty(GetDifficulty());
        }
    }

    private void HandlePipeMovement(){
            for (int i = 0; i < pipeList.Count; i++)
            {
                    Pipe pipe = pipeList[i];
                    bool isToTheRightOfTheBird = pipe.x > BIRD_X_POS;
                    pipe.Move();
                    if (isToTheRightOfTheBird && pipe.x < BIRD_X_POS){
                        score++;
                        SoundManager.play("score");
                    }
                    if (pipe.x < GameAssets.instance.PIPE_DESTROY_X_POSITION)
                        {
                            pipe.DestroySelf();
                            pipeList.Remove(pipe);
                            i--;
                        }

                }
    }

    private void SetDifficulty(Difficulty difficulty){
        switch(difficulty){
            case Difficulty.EASY: pipeSpawnTimerMax = 1.2f; break;
            case Difficulty.MEDIUM: pipeSpawnTimerMax = 1.1f;break;
            case Difficulty.HARD: pipeSpawnTimerMax = 1f; break;
            case Difficulty.IMPOSSIBLE: pipeSpawnTimerMax = 0.9f; break;
            
        }
    }
    private Difficulty GetDifficulty(){
        if (pipesSpawned >= 30) return Difficulty.IMPOSSIBLE;
        else if (pipesSpawned >= 20) return Difficulty.HARD;
        else if (pipesSpawned >= 10) return Difficulty.MEDIUM;
        return Difficulty.EASY;
    }
    

    private void CreateGapPipe(float gapY, float gapSize, float xPosition){
        CreatePipe(gapY - gapSize * .5f, xPosition, mode.DOWN);
        CreatePipe(CAM_ORTHO_SIZE * 2 - gapY - gapSize * .5f, xPosition, mode.UP); 
    }
    private void CreatePipe(float height, float xPosition, mode upOrDown){
       float pipeHeadYPos;
       float pipeBodyYPos;
       Vector2 localScale = new Vector2(1,1);
       if (upOrDown == mode.DOWN)
       {
           pipeBodyYPos = -CAM_ORTHO_SIZE;
           pipeHeadYPos = pipeBodyYPos + height - PIPE_HEAD_HEIGHT * .5f;      
       }    
       else
       {
           pipeBodyYPos = CAM_ORTHO_SIZE;
           pipeHeadYPos = pipeBodyYPos - height + PIPE_HEAD_HEIGHT * .5f;     
           localScale = new Vector2(1,-1);
       }
       
       Transform pipeBody =  Instantiate(GameAssets.instance.pfPipeBody);
       pipeBody.position = new Vector3(xPosition, pipeBodyYPos);
       pipeBody.localScale = localScale;
       
       BoxCollider2D boxCollider2D = pipeBody.GetComponent<BoxCollider2D>();
       boxCollider2D.size = new Vector2(PIPE_WiDTH, height);
       boxCollider2D.offset = new Vector2(0f, height*.5f);

       SpriteRenderer psr = pipeBody.GetComponent<SpriteRenderer>();
       psr.size = new Vector2(PIPE_WiDTH, height);
       
       
       Transform pipeHead =  Instantiate(GameAssets.instance.pfPipeHead);
       pipeHead.position = new Vector3(xPosition, pipeHeadYPos);
       
       Pipe pipe = new Pipe(pipeHead, pipeBody);
       pipeList.Add(pipe);
    }

    public int GetScore(){
        return score/2;
    }
}
