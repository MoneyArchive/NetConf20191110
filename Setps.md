
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
      2. ScaleX ScaleY => .55
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
    2. 按住 Alt + Shift，點選最右下角的選項，這樣就會將 Camera Anchor 自動設為全畫面 

9.  編輯 CountdownPage
    1. 於 Rect Transformation 點選 Anchor
    2. 按住 Alt + Shift，點選最右下角的選項，這樣就會將 Camera Anchor 自動設為全畫面