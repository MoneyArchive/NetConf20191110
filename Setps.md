
0. 切到 Game 頁籤

1. 針對圖片設定屬性， Advanced => Generate Mip Map，用來抗鋸齒；Max Size => 1024

2. 增加 UI
    1. Canvas => Render Mode => Screen Space - Camera
    2. 將 Main Camera 拖到 Render Camera
    3. Canvas Scaler => UI Sacle Mode => Scale With Screen Size
    4. Canvas Scaler => Screen Match Mode => Expand

3. 於 Canvas 加入 Object
    1. StartPage => EmptyObject
    2. OverPage => EmptyObject
    3. CountdownPage => EmptyObject
    4. ScoreText => Text
       1. 寬高設為 100
       2. Text default value => 0
       3. Best fit => checked；max size => 100
       4. color => ffffff
       5. Pos Y => 600
       6. Font => FFFFORWA
       7. Paragraph => Alignment => all center

4. 切到 Scene 頁籤
   1. 示範 3D Camera 效果

5. 增加物件
   1. Background
      1. PosX PosY => 0
      2. Order in Layer => 10
   2. Clouds
      1. PosX PosY => 0
      2. Order in Layer => 20
   3. Stars
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
      1. 寬高 => 100
      2. 設定 Source Image => play.png
      3. 調整位置到畫面下方
      4. 展開 Button => Text，刪除 Text
   2. 點選 StartPage
      1. 於 Rect Transformation 點選 Anchor
      2. 按住 Alt + Shift，點選最右下角的選項，這樣就會將 Camera Anchor 自動設為全畫面
      3. 點選 PlayButton 針對它調整 Camera Anchor
      4. PlayButton 勾選 Preserve Aspect
   3. 加入 UI => Text，命名為 PlayButton
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
    5. Test
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

16. 將 pipe 加入到 Environment 中 (注意 Z Index)，命名為 bottom-pipe
    1.  Order in Layer => 60
    2.  Add Componement => Box Collider 2D
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