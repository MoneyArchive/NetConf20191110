
0. 切到 Game 頁籤

1. 針對圖片設定屬性， Advanced => Generate Mip Map，用來抗鋸齒；Max Size => 1024

2. 增加 UI
    1. Canvas => Render Mode => Screen Space - Camera
    2. 將 Main Camera 拖到 Render Camera
    3. Canvas Scaler => UI Sacle Mode => Scale With Screen Size
    4. Canvas Scaler => Screen Match Mode => Expand

3. 於 Canvas 加入 Empty Object
    1. StartPage => EmptyObject
    2. OverPage => EmptyObject
    3. CountdownPage => EmptyObject
    4. ScoreText => UI =>Text
       1. 寬高設為 100
       2. Text default value => 0
       3. Best fit => checked；max size => 100
       4. color => ffffff
       5. Pos Y => 600
       6. Font => FFFFORWA
       7. Paragraph => Alignment => all center

4. 切到 Scene 頁籤
   1. 示範 3D Camera 效果

5. 透過拖曳圖片增加物件
   1. Background
      1. PosX PosY => 0
      2. Order in Layer => 10
   2. Cloud
      1. PosX PosY => 0
      2. Order in Layer => 20
   3. Star
      1. PosX PosY => 0
      2. Order in Layer => 30
   4. Bird
      1. PosX PosY => 0
      2. ScaleX ScaleY => .3
      3. Order in Layer => 40
      4. Color => 隨意挑一個顏色

6. 針對 ScoreText 調整 Camera Anchor

7. 編輯 StartPage
   1. 加入 UI => Button，命名為 PlayButton
      1. 寬高 => 200
      2. 設定 Source Image => play.png
      3. 調整位置到畫面下方
      4. 展開 Button => Text，刪除 Text
      5. 調整 Camera Anchor
   2. 點選 StartPage
      1. 於 Rect Transformation 點選 Anchor
      2. 按住 Alt + Shift，點選最右下角的選項，這樣就會將 Camera Anchor 自動設為全畫面
      3. 點選 PlayButton 針對它調整 Camera Anchor
      4. PlayButton 勾選 Preserve Aspect
   3. 加入 UI => Text
      1. Paragraph => Alignment => all center
      2. Color => White
      3. Text => HighScore: 0
      4. Font Size => 60
      5. Font => FFFFORWA
      6. Width => 582
      7. Height => 178
      8. Best fit => 勾選
      9. 調整位置到 開始按鈕上方
      10. 調整 Camera Anchor

8. 編輯 OverPage
    1. 於 Rect Transformation 點選 Anchor
       1. 按住 Alt + Shift，點選最右下角的選項，這樣就會將 Camera Anchor 自動設為全畫面 
    2. 從 StartPage 複製 Button 與 Text；Button 命名為 ReplayButton
    3. ReplayButton 與 Text
       1. 按下 Shift，Reset camera anchor 到中間
    4. ReplayButton
       1. PosX PosY => 0
       2. Source Image => replay.png
       3. 調整 Camera Anchor
    5. Text
       1. 移到 ReplayButton 上方
       2. Text => Score: 0
       3. Width => 387
       4. 調整 Camera Anchor

9.  編輯 CountdownPage
    1. 於 Rect Transformation 點選 Anchor
       1. 按住 Alt + Shift，點選最右下角的選項，這樣就會將 Camera Anchor 自動設為全畫面
    2. 複製 ScoreText，改名為 CountdownText
    3. PosX PosY => 0
    4. 調整 Camera Anchor

10. 新增一個 Empty Object，命名為: Environment
    1.  將 Background, Cloud, Star, Bird 放到其底下

11. 執行看看目前結果

12. 針對 bird
    1.  Add Componement => Rigidbody 2D
        1.  Constraints => 勾選 Z

13. 再執行一次，可以看到鳥掉下去了

14. 針對 bird
    1.  Add Componement => Circle Collider 2D
        1.  Raduis => 0.74
        2.  IsTrigger => 勾選；代表物件互相可以通過彼此，而非撞到彼此

15. 將 ground 加入到 Environment 中 (注意 Z Index)
    1.  Order in Layer => 70
    2.  Add Componement => Box Collider 2D
        1.  調整 SizeY 符合 Ground 大小
        2.  調整 OffsetY 對應到 ground
        3.  IsTrigger => 勾選；代表物件互相可以通過彼此，而非撞到彼此

16. 將 pipe 加入到 root 中 (注意 Z Index)，命名為 bottom-pipe
    1.  Order in Layer => 60
    2.  Scale= > .4
    3.  Add Componement => Box Collider 2D
        1.  調整 SizeY 符合 Ground 大小
        2.  調整 OffsetY 對應到 ground
        3.  IsTrigger => 勾選；代表物件互相可以通過彼此，而非撞到彼此

17. 複製 bottom-pipe，命名為 top-pipe
    1.  RotationZ => 180
    2.  調整位置與兩個pipe之間的間隔

18. 新增 Empty Object，命名為 pipe
    1.  PosX PosY => 0
    2.  將 bottom-pipe 與 top-pipe 移到其底下
    3.  就可以透過移動 pipe 而同時移動上下 pipe
    4.  於 pipe 底下新增 Empty Object，命名為 score-zone
        1.  Add Componement => Box Collider 2D
            1.  PosX PosY => 0
            2.  調整 SizeX SizeY 符合通過大小
            3.  調整 OffsetY 對應到 ground
            4.  IsTrigger => 勾選；代表物件互相可以通過彼此，而非撞到彼此

19. 新增兩個 TAG: DeadZone、ScoreZone
    1.  設定 ground, bottom-pipe, top-pipe => DeadZone
    2.  設定 score-zone => ScoreZone

20. 新增資料夾: prefabs
    1.  將 pipe, clouds, star 拉進去

21. 新增資料夾: scripts
    1.  新增 C# 檔案 => TapController
    2.  點選開啟

22. TapController
    1.  class add Attribute
    ``` csharp
        [RequireComponent(typeof(Rigidbody2D))]
    ```
    1.  加入參數宣告
    ``` csharp
        public float tapForce = 10;
        public float tiltSmooth = 5;
        public Vector3 startPos;

        private Rigidbody2D rigidbody;
        // fancy form of rotation
        private Quaternion downRotation;
        private Quaternion forwardRotation;
    ```
    1. 於 Start 方法內加入
    ``` csharp
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    ```
    1. 於 Update 方法內加入
    ``` csharp
        // 0: left, 1: right
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = forwardRotation;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        // source to target value in certain time
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    ```
    1. 加入 OnTriggerEnter2D 方法
    ``` csharp
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "ScoreZone")
            {
                // register score event
                // play sound
            }

            if (collider.gameObject.tag == "DeadZone")
            {
                rigidbody.simulated = false;
                // register a dead event
                // play a sound
            }
        }
    ```

23. 新增 C# 檔案 => GameManager.cs
    1.  點選開啟
    2.  加入初始化參數
    ``` csharp
        // usually use for scene switch
        public static GameManager Instance;

        public delegate void GameDelegate();

        public static event GameDelegate OnGameStarted;
        public static event GameDelegate OnGameOverConfirmed;

        public GameObject startPage;
        public GameObject overPage;
        public GameObject countdownPage;
        public Text scoreText;
        public bool GameOver => isGameOver;
        public int Score => score;

        private int score = 0;
        private bool isGameOver = false;
    ```
    1.  加入 PageState 列舉
    ``` csharp
        public enum PageState
        {
            None,
            Start,
            GameOver,
            Countdown
        }
    ```
    1.  加入 Awake 方法
    ``` csharp
        void Awake()
        {
            Instance = this;
        }
    ```
    1. 加入 SetPageState 方法
    ``` csharp
        void SetPageState(PageState state)
        {
            switch (state)
            {
                case PageState.None:
                    startPage.SetActive(false);
                    overPage.SetActive(false);
                    countdownPage.SetActive(false);
                    break;
                case PageState.Start:
                    startPage.SetActive(true);
                    overPage.SetActive(false);
                    countdownPage.SetActive(false);
                    break;
                case PageState.GameOver:
                    startPage.SetActive(false);
                    overPage.SetActive(true);
                    countdownPage.SetActive(false);
                    break;
                case PageState.Countdown:
                    startPage.SetActive(false);
                    overPage.SetActive(false);
                    countdownPage.SetActive(true);
                    break;
            }
        }
    ```
    1. 加入 ConfirmGameOver 與 StartGame 方法
    ``` csharp
        public void ConfirmGameOver()
        {
            // activated when replay is click
            OnGameOverConfirmed();
            scoreText.text = "0";
            SetPageState(PageState.Start);
        }

        public void StartGame()
        {
            // activated when play is click
            SetPageState(PageState.Countdown);
        }
    ```

24. 於 MainCamera 
    1.  Add Componement => GameManager
    2.  將各個參數選好，如 StartPage, OverPage 等等
    3.  CountdownText: Add Componement => CountdownText

25. 於 StartPage.PlayButton
    1.  新增 OnClick 方法，先設定參考 MainCamera，再選擇 GameManager => StartGame

26. 於 OverPage.ReplayButton
    1.  新增 OnClick 方法，先設定參考 MainCamera，再選擇 GameManager => ConfirmGameOver

27. 新增 C# 檔案 => CountdownText
    1.  class add Attribute
    ``` csharp
        [RequireComponent(typeof(Text))]
    ```
    1.  加入初始化參數
    ``` csharp
        public delegate void CountdownFinish();
        public static event CountdownFinish OnCountdownFinished;

        private Text countdown;
    ```
    1. 加入 ConfirmGameOver 與 StartGame 方法
    ``` csharp
        // call everytime when set page active
        void OnEnable()
        {
            countdown = GetComponent<Text>();
            countdown.text = "3";
            StartCoroutine("Countdown");
        }

        IEnumerator Countdown()
        {
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                countdown.text = (count - i).ToString();
                yield return new WaitForSeconds(1);
            }

            OnCountdownFinished();
        }
    ```

28. 於 GameManager.cs
    1.  
    ``` csharp
        void OnEnable()
        {
            CountdownText.OnCountdownFinished += OnCountdownFinished;
        }

        void OnDisable()
        {
            CountdownText.OnCountdownFinished -= OnCountdownFinished;
        }

        void OnCountdownFinished()
        {
            SetPageState(PageState.None);
            OnGameStarted();
            score = 0;
            isGameOver = false;
        }
    ```

29. 於 TapController.cs
    1.  參數加入
    ``` csharp
        public delegate void PlayerDelegate();
        public static event PlayerDelegate OnPlayerDied;
        public static event PlayerDelegate OnPlayerScored;
    ```
    1. OnTriggerEnter2D 加入呼叫 `OnPlayerScored` and `OnPlayerDied` 
    ``` csharp
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "ScoreZone")
            {
                // register score event
                OnPlayerScored();
                // play sound
            }

            if (collider.gameObject.tag == "DeadZone")
            {
                rigidbody.simulated = false;
                // register a dead event
                OnPlayerDied();
                // play a sound
            }
        }
    ```
    1. 加入 OnEnable 與 OnDisable 方法
    ``` csharp
        void OnEnable()
        {
            GameManager.OnGameStarted += OnGameStarted;
            GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
        }

        void OnDisable()
        {
            GameManager.OnGameStarted -= OnGameStarted;
            GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
        }
    ```
    1. 加入 OnGameOverConfirmed 與 OnGameStarted 方法
    ``` csharp
        private void OnGameOverConfirmed()
        {
            transform.localPosition = startPos;
            transform.rotation = Quaternion.identity;
        }

        private void OnGameStarted()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.simulated = true;
        }
    ```

30. 於 GameManager.cs
    1.  更新 OnEnable and OnDisable 加入與移除 OnPlayerScored and OnPlayerDied 事件
    ``` csharp
        void OnEnable()
        {
            CountdownText.OnCountdownFinished += OnCountdownFinished;
            TapController.OnPlayerScored += OnPlayerScored;
            TapController.OnPlayerDied += OnPlayerDied;
        }

        void OnDisable()
        {
            CountdownText.OnCountdownFinished -= OnCountdownFinished;
            TapController.OnPlayerScored -= OnPlayerScored;
            TapController.OnPlayerDied -= OnPlayerDied;
        }
    ```
    1. 加入 OnPlayerDied and OnPlayerScored 方法
    ``` csharp
        private void OnPlayerDied()
        {
            isGameOver = true;
            int savedScore = PlayerPrefs.GetInt("HighScore");
            if (score > savedScore)
                PlayerPrefs.SetInt("HighScore", score);
            SetPageState(PageState.GameOver);
        }

        private void OnPlayerScored()
        {
            score++;
            scoreText.text = score.ToString();
        }
    ```
    
31. 將 TapController 指定給 Bird
    1.  TapForce: 250
    2.  TiltSmooth: 2

32. 將 CountdownText 指定給 CountdownPage.CountdownText

33. 執行起來看看

34. 發現重置後角度會往下掉，修正方法
    1.  於 TapController.cs 中
        1. 加入參數
        ``` csharp
            private GameManager gameManager;
        ```
        1. 更新 Start，最後一行
        ``` csharp
            gameManager = GameManager.Instance;
        ```
        1. 更新 Update，最前面
        ``` csharp
            if (gameManager.GameOver == true)
                return;
        ```

35. 執行起來看看

36. 加入 HighScoreText.cs
    1.  class add Attribute
    ``` csharp
        [RequireComponent(typeof(Text))]
    ```
    1.  加入初始化參數
    ``` csharp
        private Text highScore;
    ```
    1. 加入 OnEnable 方法
    ``` csharp
        void OnEnable()
        {
            highScore = GetComponent<Text>();
            highScore.text =  "HighScore: "+PlayerPrefs.GetInt("HighScore").ToString();
        }
    ```
    1. 將 HighScoreText.cs 指定給 StartPage 的 Text 當作 Componment

37. 接下來就是要讓場景可以開始移動了，使用 Parallaxer
    1. 於 Environment 下新增三個 Empty Object: Clouds, Stars, Pipes
       1. 將 Parallaxer 作為 Componment 加入到上面的三個物件中
    2. 新增 C# 檔案 => Parallaxer
    3. 編輯 Parallaxer.cs
        1.  加入一個 class
        ``` csharp
            class PoolObject
            {
                public Transform transform;
                public bool IsInUse;

                public PoolObject(Transform t)
                {
                    transform = t;
                }

                public void SetUse()
                {
                    IsInUse = true;
                }

                public void SetUnUse()
                {
                    IsInUse = false;
                }
            }
        ```
        1. 加入一個 struct
        ``` csharp
            // for pipe Y gap
            [Serializable]
            public struct YSpawnRange
            {
                public float MinY;
                public float MaxY;
            }
        ```
        1. 加入初始化參數
        ``` csharp
            public GameObject Prefab;
            public int PoolSize;
            public float ShiftSpeed;
            public float SpawnRate;
            public Vector3 DefaultSpawnPos;
            public bool IsSpawnImmediate;
            // particle prewarm
            public Vector3 ImmediateSpawnPos;
            // fit screen ratio
            public Vector2 TargetAspectRatio;
            public YSpawnRange YSpawnRange;

            private float spawnTimer;
            private float targetAspect;
            private PoolObject[] poolObjects;
            private GameManager game;
        ```
        1. 取代 Parallaxer 內所有方法
        ``` csharp
            void Awake()
            {
                Configure();
            }

            void Start()
            {
                game = GameManager.Instance;
            }

            void OnEnable()
            {
                GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
            }

            void OnDisable()
            {
                GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
            }

            void OnGameOverConfirmed()
            {
                for (int i = 0; i < poolObjects.Length; i++)
                {
                    poolObjects[i].SetUnUse();
                    poolObjects[i].transform.position = Vector3.one * 1000;
                }
                Configure();
            }

            void Update()
            {
                if (game.GameOver) return;

                Shift();
                spawnTimer += Time.deltaTime;
                if (spawnTimer > SpawnRate)
                {
                    Spawn();
                    spawnTimer = 0;
                }
            }

            void Configure()
            {
                //spawning pool objects
                targetAspect = TargetAspectRatio.x / TargetAspectRatio.y;
                poolObjects = new PoolObject[PoolSize];
                for (int i = 0; i < poolObjects.Length; i++)
                {
                    GameObject go = Instantiate(Prefab) as GameObject;
                    Transform t = go.transform;
                    t.SetParent(transform);
                    t.position = Vector3.one * 1000;
                    poolObjects[i] = new PoolObject(t);
                }

                if (IsSpawnImmediate)
                {
                    SpawnImmediate();
                }
            }

            void Spawn()
            {
                //moving pool objects into place
                Transform t = GetPoolObject();
                if (t == null) return;
                Vector3 pos = Vector3.zero;
                pos.y = Random.Range(YSpawnRange.MinY, YSpawnRange.MaxY);
                pos.x = (DefaultSpawnPos.x * Camera.main.aspect) / targetAspect;
                t.position = pos;
            }

            void SpawnImmediate()
            {
                Transform t = GetPoolObject();
                if (t == null) return;
                Vector3 pos = Vector3.zero;
                pos.y = Random.Range(YSpawnRange.MinY, YSpawnRange.MaxY);
                pos.x = (ImmediateSpawnPos.x * Camera.main.aspect) / targetAspect;
                t.position = pos;
                Spawn();
            }

            void Shift()
            {
                //loop through pool objects 
                //moving them
                //discarding them as they go off screen
                for (int i = 0; i < poolObjects.Length; i++)
                {
                    poolObjects[i].transform.position += Vector3.right * ShiftSpeed * Time.deltaTime;
                    CheckDisposeObject(poolObjects[i]);
                }
            }

            void CheckDisposeObject(PoolObject poolObject)
            {
                //place objects off screen
                if (poolObject.transform.position.x < (-DefaultSpawnPos.x * Camera.main.aspect) / targetAspect)
                {
                    poolObject.SetUnUse();
                    poolObject.transform.position = Vector3.one * 1000;
                }
            }

            Transform GetPoolObject()
            {
                //retrieving first available pool object
                for (int i = 0; i < poolObjects.Length; i++)
                {
                    if (!poolObjects[i].IsInUse)
                    {
                        poolObjects[i].SetUse();
                        return poolObjects[i].transform;
                    }
                }
                return null;
            }
        ```

38. Pipes Parallaxer 設定
    1.  Prefab: Pipe
    2.  PoolSize: 10
    3.  ShiftSpeed: -1.25
    4.  Spawn Rate: 3
    5.  Default Spawn Pos: 3.58
    6.  MinY: -1.1
    7.  MaxY: 1.36

39. Clouds Parallaxer 設定
    1.  Prefab: Pipe
    2.  PoolSize: 10
    3.  ShiftSpeed: -1.25
    4.  Spawn Rate: 3
    5.  Default Spawn Pos: 3.58
    6.  MinY: -1.1
    7.  MaxY: 1.36

40. Stars Parallaxer 設定
    1.  Prefab: Pipe
    2.  PoolSize: 10
    3.  ShiftSpeed: -1.25
    4.  Spawn Rate: 3
    5.  Default Spawn Pos: 3.58
    6.  MinY: -1.1
    7.  MaxY: 1.36